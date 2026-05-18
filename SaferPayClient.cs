using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using SaferPay.Config;
using SaferPay.Exceptions;
using SaferPay.Interfaces;
using SaferPay.Models.Core;
using SaferPay.Models.Management;
using System.Reflection;

namespace SaferPay;


/// <summary>
/// SaferPayClient
/// </summary>
public class SaferPayClient : ISaferPayClient
{

    protected readonly SaferPaySettings _settings;
    private readonly JsonSerializerSettings _jsonSerializerSettings;

    public string CustomerId => _settings.CustomerId;

    public string TerminalId => _settings.TerminalId;

    public ITransaction Transaction => new SaferPay.Channels.Transaction(this);

    public IPaymentPage PaymentPage => new SaferPay.Channels.PaymentPage(this);

    public ISecureCardData SecureCardData => new SaferPay.Channels.SecureCardData(this);

    public IBatch Batch => new SaferPay.Channels.Batch(this);

    public IOmniChannel OmniChannel => new SaferPay.Channels.OmniChannel(this);

    public IManagementApi ManagementApi => new SaferPay.Channels.ManagementApi(this);

    public SaferPayClient(SaferPaySettings settings) : this(settings, JsonSettings.Default) { }

    public SaferPayClient(string customerId, string terminalId, string userName, string passWord, bool sandBox = false)
        : this(new SaferPaySettings(customerId, terminalId, userName, passWord, sandBox), JsonSettings.Default) { }

    public SaferPayClient(SaferPaySettings settings, JsonSerializerSettings jsonSerializerSettings)
    {
        _settings = settings;
        _jsonSerializerSettings = jsonSerializerSettings;
    }

    /// <summary>
    /// Request Id
    /// </summary>
    /// <returns></returns>
    protected virtual string GenerateRequestId() => Guid.NewGuid().ToString("n");

    /// <summary>
    /// Request Headers
    /// </summary>
    /// <returns></returns>
    protected virtual RequestHeader CreateRequestHeader() => new RequestHeader
    {
        CustomerId = _settings.CustomerId,
        SpecVersion = SaferPayApiConstants.Version,
        RequestId = GenerateRequestId(),
        RetryIndicator = 0
    };

    /// <summary>
    /// Send Async Method
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    /// <typeparam name="TRequest"></typeparam>
    /// <param name="path"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public virtual async Task<TResponse> SendAsync<TResponse, TRequest>(string path, TRequest request) where TRequest : RequestBase where TResponse : ResponseBase
    {

        try
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            request.RequestHeader = CreateRequestHeader();
            var uri = new Uri(_settings.BaseUri, path);

            var opt = new RestClientOptions(uri);
            opt.Authenticator = new HttpBasicAuthenticator(_settings.Username, _settings.Password);

            using var client = new RestClient(opt);
            var req = new RestRequest();
            req.Method = Method.Post;

            var json = request.Json();
            req.AddParameter("application/json", json, ParameterType.RequestBody);

            var res = await client.ExecuteAsync(req);
            if (res != null && res.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var response = JsonConvert.DeserializeObject<TResponse>(res.Content!, _jsonSerializerSettings);
                response!.ResponseStatus = Enums.ResponseStatus.SUCCESS;
                return response;
            }
            else
            {
                var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(res.Content, _jsonSerializerSettings);

                if (!_settings.ThrowExceptionOnFail)
                {
                    var response = Activator.CreateInstance<TResponse>();
                    response.Error = errorResponse;
                    response.ResponseStatus = Enums.ResponseStatus.ERROR;
                    return response;
                }

                throw new SaferPayException(res.StatusCode, errorResponse);
            }
        }

        catch (SaferPayException spex)
        {
            if (!_settings.ThrowExceptionOnFail)
            {
                var response = Activator.CreateInstance<TResponse>();
                response.Error = new ErrorResponse();
                response.Error.ErrorMessage = spex.Message.ToString();
                response.ResponseStatus = Enums.ResponseStatus.ERROR;
                return response;
            }

            if (_settings.ThrowExceptionOnFail)
            {
                throw;
            }
        }
        catch (Exception ex)
        {

            if (!_settings.ThrowExceptionOnFail)
            {
                var response = Activator.CreateInstance<TResponse>();
                response.Error = new ErrorResponse();
                response.Error.ErrorMessage = ex.Message.ToString();
                response.ResponseStatus = Enums.ResponseStatus.ERROR;
                return response;
            }

            throw;

        }

        return null;
    }

    public void Dispose()
    {
        // The client holds no long-lived disposable state. RestClient instances
        // are created and disposed per request, so there is nothing to release here.
    }

    /// <summary>
    /// Send Method
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    /// <typeparam name="TRequest"></typeparam>
    /// <param name="path"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="SaferPayException"></exception>
    public TResponse Send<TResponse, TRequest>(string path, TRequest request) where TResponse : ResponseBase where TRequest : RequestBase
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        request.RequestHeader = CreateRequestHeader();
        var uri = new Uri(_settings.BaseUri, path);

        var opt = new RestClientOptions(uri);
        opt.Authenticator = new HttpBasicAuthenticator(_settings.Username, _settings.Password);

        using var client = new RestClient(opt);
        var req = new RestRequest();
        req.Method = Method.Post;

        var json = request.Json();
        req.AddParameter("application/json", json, ParameterType.RequestBody);

        var res = client.Execute(req);
        if (res != null && res.StatusCode == System.Net.HttpStatusCode.OK)
        {
            var response = JsonConvert.DeserializeObject<TResponse>(res.Content!, _jsonSerializerSettings);
            response!.ResponseStatus = Enums.ResponseStatus.SUCCESS;
            return response;
        }
        else
        {
            var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(res.Content, _jsonSerializerSettings);

            if (!_settings.ThrowExceptionOnFail)
            {
                var response = Activator.CreateInstance<TResponse>();
                response.Error = errorResponse;
                response.ResponseStatus = Enums.ResponseStatus.ERROR;
                return response;
            }

            throw new SaferPayException(res.StatusCode, errorResponse);
        }
    }

    public TResponse Get<TResponse>(string path) where TResponse : Models.Management.RestResponseBase
    {
        var response = GetAsync<TResponse>(path).GetAwaiter().GetResult();
        return response;
    }

    public async Task<TResponse> GetAsync<TResponse>(string path) where TResponse : Models.Management.RestResponseBase
    {
        var uri = new Uri(_settings.BaseUri, path);
        var opt = new RestClientOptions(uri);

        opt.Authenticator = new HttpBasicAuthenticator(_settings.Username, _settings.Password);
        using var client = new RestClient(opt);

        var req = new RestRequest();
        req.Method = Method.Get;

        req.AddHeader("Saferpay-ApiVersion", SaferPayApiConstants.Version);
        req.AddHeader("Saferpay-RequestId", Guid.NewGuid().ToString());

        req.AddHeader("Content-Type", "application/json; charset=utf-8");
        req.AddHeader("Accept", "application/json");

        var res = await client.ExecuteAsync(req);

        // 200 OK
        if (res.IsSuccessful && res.StatusCode == System.Net.HttpStatusCode.OK)
        {
            var response = JsonConvert.DeserializeObject<TResponse>(res.Content ?? "{}", _jsonSerializerSettings);
            if (response != null)
            {
                response.ResponseStatus = Enums.ResponseStatus.SUCCESS;
                return response;
            }
        }

        // 404 Not Found
        if (res.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            var notFoundError = new ErrorResponse { ErrorMessage = "Requested resource not found (404)." };

            if (!_settings.ThrowExceptionOnFail)
            {
                var response = Activator.CreateInstance<TResponse>();
                response.Error = notFoundError;
                response.ResponseStatus = Enums.ResponseStatus.ERROR;
                return response;
            }
            throw new SaferPayException(res.StatusCode, notFoundError);
        }

        // Other Errors (400, 401, 500 vb.)
        ErrorResponse errorResponse = null;
        if (!string.IsNullOrEmpty(res.Content))
        {
            errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(res.Content, _jsonSerializerSettings);
        }

        errorResponse ??= new ErrorResponse { ErrorMessage = res.ErrorMessage ?? "Unknown API Error" };

        if (!_settings.ThrowExceptionOnFail)
        {
            var response = Activator.CreateInstance<TResponse>();
            response.Error = errorResponse;
            response.ResponseStatus = Enums.ResponseStatus.ERROR;
            return response;
        }

        throw new SaferPayException(res.StatusCode, errorResponse);

    }

    public TResponse Get<TResponse, TRequest>(string path, TRequest request)
        where TResponse : Models.Management.RestResponseBase
        where TRequest : RestRequestBase
    {
        var response = GetAsync<TResponse, TRequest>(path, request).GetAwaiter().GetResult();
        return response;
    }

    public async Task<TResponse> GetAsync<TResponse, TRequest>(string path, TRequest request)
        where TResponse : Models.Management.RestResponseBase
        where TRequest : RestRequestBase
    {
        var opt = new RestClientOptions(_settings.BaseUri);

        opt.Authenticator = new HttpBasicAuthenticator(_settings.Username, _settings.Password);
        using var client = new RestClient(opt);

        var req = new RestRequest(path, Method.Get);

        // 1. Query Parametrelerini Otomatik Ekleme
        if (request != null)
        {
            // 1. Nesnenin tüm property'lerini alıyoruz
            var properties = typeof(TRequest).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in properties)
            {
                // 2. [JsonIgnore] varsa bu property'yi tamamen atla
                if (Attribute.IsDefined(prop, typeof(JsonIgnoreAttribute)))
                    continue;

                // 3. [JsonProperty] niteliğini al
                var jsonProperty = prop.GetCustomAttribute<JsonPropertyAttribute>();

                // Eğer JsonProperty atanmamışsa standart ismini kullan, atanmışsa oradaki ismi kullan
                string paramName = jsonProperty != null ? jsonProperty.PropertyName : prop.Name;

                var value = prop.GetValue(request);

                // 4. Sadece null olmayan değerleri ekle
                if (value != null)
                {
                    // Değer bir Enum ise, string karşılığını (USD, TRY vb.) gönder
                    if (prop.PropertyType.IsEnum || (Nullable.GetUnderlyingType(prop.PropertyType)?.IsEnum == true))
                    {
                        req.AddQueryParameter(paramName, value.ToString());
                    }
                    // DateTime kontrolü (Eğer unutup JsonIgnore koymazsanız patlamasın diye)
                    else if (value is DateTime dt)
                    {
                        req.AddQueryParameter(paramName, dt.ToString("yyyy-MM-ddTHH:mm"));
                    }
                    else
                    {
                        req.AddQueryParameter(paramName, value.ToString());
                    }
                }
            }
        }

        // 2. Zorunlu Saferpay Header'ları
        req.AddHeader("Saferpay-ApiVersion", SaferPayApiConstants.Version);
        req.AddHeader("Saferpay-RequestId", Guid.NewGuid().ToString());
        req.AddHeader("Accept", "application/json");
        req.AddHeader("Content-Type", "application/json; charset=utf-8");

        var res = await client.ExecuteAsync(req);

        // 3. Başarı Kontrolü (200 OK)
        if (res.IsSuccessful && res.StatusCode == System.Net.HttpStatusCode.OK)
        {
            var response = JsonConvert.DeserializeObject<TResponse>(res.Content ?? "{}", _jsonSerializerSettings);
            if (response != null)
            {
                response.ResponseStatus = Enums.ResponseStatus.SUCCESS;
                return response;
            }
        }

        // 404 Not Found
        if (res.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            var notFoundError = new ErrorResponse { ErrorMessage = "Requested resource not found (404)." };

            if (!_settings.ThrowExceptionOnFail)
            {
                var response = Activator.CreateInstance<TResponse>();
                response.Error = notFoundError;
                response.ResponseStatus = Enums.ResponseStatus.ERROR;
                return response;
            }
            throw new SaferPayException(res.StatusCode, notFoundError);
        }

        // Other Errors (400, 401, 500 vb.)
        ErrorResponse errorResponse = null;
        if (!string.IsNullOrEmpty(res.Content))
        {
            errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(res.Content, _jsonSerializerSettings);
        }

        errorResponse ??= new ErrorResponse { ErrorMessage = res.ErrorMessage ?? "Unknown API Error" };

        if (!_settings.ThrowExceptionOnFail)
        {
            var response = Activator.CreateInstance<TResponse>();
            response.Error = errorResponse;
            response.ResponseStatus = Enums.ResponseStatus.ERROR;
            return response;
        }

        throw new SaferPayException(res.StatusCode, errorResponse);
    }

    public TResponse Post<TResponse>(string path) where TResponse : Models.Management.RestResponseBase
    {
        var response = PostAsync<TResponse>(path).GetAwaiter().GetResult();
        return response;
    }

    public async Task<TResponse> PostAsync<TResponse>(string path) where TResponse : Models.Management.RestResponseBase
    {
        var uri = new Uri(_settings.BaseUri, path);
        var opt = new RestClientOptions(uri);

        opt.Authenticator = new HttpBasicAuthenticator(_settings.Username, _settings.Password);
        using var client = new RestClient(opt);

        var req = new RestRequest();
        req.Method = Method.Post;

        req.AddHeader("Saferpay-ApiVersion", SaferPayApiConstants.Version);
        req.AddHeader("Saferpay-RequestId", Guid.NewGuid().ToString());

        req.AddHeader("Content-Type", "application/json; charset=utf-8");
        req.AddHeader("Accept", "application/json");

        var res = await client.ExecuteAsync(req);

        // 200 OK
        if (res.IsSuccessful && res.StatusCode == System.Net.HttpStatusCode.OK)
        {
            var response = JsonConvert.DeserializeObject<TResponse>(res.Content ?? "{}", _jsonSerializerSettings);
            if (response != null)
            {
                response.ResponseStatus = Enums.ResponseStatus.SUCCESS;
                return response;
            }
        }

        // 404 Not Found
        if (res.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            var notFoundError = new ErrorResponse { ErrorMessage = "Requested resource not found (404)." };

            if (!_settings.ThrowExceptionOnFail)
            {
                var response = Activator.CreateInstance<TResponse>();
                response.Error = notFoundError;
                response.ResponseStatus = Enums.ResponseStatus.ERROR;
                return response;
            }
            throw new SaferPayException(res.StatusCode, notFoundError);
        }

        // Other Errors (400, 401, 500 vb.)
        ErrorResponse errorResponse = null;
        if (!string.IsNullOrEmpty(res.Content))
        {
            errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(res.Content, _jsonSerializerSettings);
        }

        errorResponse ??= new ErrorResponse { ErrorMessage = res.ErrorMessage ?? "Unknown API Error" };

        if (!_settings.ThrowExceptionOnFail)
        {
            var response = Activator.CreateInstance<TResponse>();
            response.Error = errorResponse;
            response.ResponseStatus = Enums.ResponseStatus.ERROR;
            return response;
        }

        throw new SaferPayException(res.StatusCode, errorResponse);
    }

    public TResponse Post<TResponse, TRequest>(string path, TRequest request)
        where TResponse : Models.Management.RestResponseBase
        where TRequest : RestRequestBase
    {
        var response = PostAsync<TResponse, TRequest>(path, request).GetAwaiter().GetResult();
        return response;
    }

    public async Task<TResponse> PostAsync<TResponse, TRequest>(string path, TRequest request)
        where TResponse : Models.Management.RestResponseBase
        where TRequest : RestRequestBase
    {
        var uri = new Uri(_settings.BaseUri, path);
        var opt = new RestClientOptions(uri);

        opt.Authenticator = new HttpBasicAuthenticator(_settings.Username, _settings.Password);
        using var client = new RestClient(opt);

        var req = new RestRequest();
        req.Method = Method.Post;

        var json = request.Json();
        req.AddParameter("application/json", json, ParameterType.RequestBody);

        req.AddHeader("Saferpay-ApiVersion", SaferPayApiConstants.Version);
        req.AddHeader("Saferpay-RequestId", Guid.NewGuid().ToString());

        req.AddHeader("Content-Type", "application/json; charset=utf-8");
        req.AddHeader("Accept", "application/json");

        var res = await client.ExecuteAsync(req);

        // 200 OK
        if (res.IsSuccessful && res.StatusCode == System.Net.HttpStatusCode.OK)
        {
            var response = JsonConvert.DeserializeObject<TResponse>(res.Content ?? "{}", _jsonSerializerSettings);
            if (response != null)
            {
                response.ResponseStatus = Enums.ResponseStatus.SUCCESS;
                return response;
            }
        }

        // 404 Not Found
        if (res.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            var notFoundError = new ErrorResponse { ErrorMessage = "Requested resource not found (404)." };

            if (!_settings.ThrowExceptionOnFail)
            {
                var response = Activator.CreateInstance<TResponse>();
                response.Error = notFoundError;
                response.ResponseStatus = Enums.ResponseStatus.ERROR;
                return response;
            }
            throw new SaferPayException(res.StatusCode, notFoundError);
        }

        // Other Errors (400, 401, 500 vb.)
        ErrorResponse errorResponse = null;
        if (!string.IsNullOrEmpty(res.Content))
        {
            errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(res.Content, _jsonSerializerSettings);
        }

        errorResponse ??= new ErrorResponse { ErrorMessage = res.ErrorMessage ?? "Unknown API Error" };

        if (!_settings.ThrowExceptionOnFail)
        {
            var response = Activator.CreateInstance<TResponse>();
            response.Error = errorResponse;
            response.ResponseStatus = Enums.ResponseStatus.ERROR;
            return response;
        }

        throw new SaferPayException(res.StatusCode, errorResponse);
    }

    public TResponse Delete<TResponse>(string path) where TResponse : Models.Management.RestResponseBase
    {
        var response = DeleteAsync<TResponse>(path).GetAwaiter().GetResult();
        return response;
    }

    public async Task<TResponse> DeleteAsync<TResponse>(string path) where TResponse : Models.Management.RestResponseBase
    {
        var uri = new Uri(_settings.BaseUri, path);
        var opt = new RestClientOptions(uri);

        opt.Authenticator = new HttpBasicAuthenticator(_settings.Username, _settings.Password);
        using var client = new RestClient(opt);

        // Client'ın sınıf düzeyinde tek bir instance olduğunu varsayıyoruz. 
        // Eğer metot içinde oluşturmak zorundaysanız bile RestRequest'i path ile başlatın.
        var req = new RestRequest(path, Method.Delete);

        req.AddHeader("Saferpay-ApiVersion", SaferPayApiConstants.Version);
        req.AddHeader("Saferpay-RequestId", Guid.NewGuid().ToString());
        req.AddHeader("Content-Type", "application/json; charset=utf-8");
        req.AddHeader("Accept", "application/json");

        var res = await client.ExecuteAsync(req);

        // Başarı Durumu (200 OK veya 204 No Content)
        if (res.IsSuccessful)
        {
            // 204 No Content durumunda Content null/empty olabilir.
            var content = string.IsNullOrWhiteSpace(res.Content) ? "{}" : res.Content;
            var response = JsonConvert.DeserializeObject<TResponse>(content, _jsonSerializerSettings);

            response ??= Activator.CreateInstance<TResponse>();
            response.ResponseStatus = Enums.ResponseStatus.SUCCESS;
            return response;
        }

        // 404 Not Found
        if (res.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            var notFoundError = new ErrorResponse { ErrorMessage = "Requested resource not found (404)." };

            if (!_settings.ThrowExceptionOnFail)
            {
                var response = Activator.CreateInstance<TResponse>();
                response.Error = notFoundError;
                response.ResponseStatus = Enums.ResponseStatus.ERROR;
                return response;
            }
            throw new SaferPayException(res.StatusCode, notFoundError);
        }

        // Diğer Hata Durumları
        ErrorResponse errorResponse = null;
        if (!string.IsNullOrEmpty(res.Content))
        {
            try
            {
                errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(res.Content, _jsonSerializerSettings);
            }
            catch { /* JSON parse hatası ihtimaline karşı */ }
        }

        errorResponse ??= new ErrorResponse { ErrorMessage = res.ErrorMessage ?? $"API Error: {res.StatusCode}" };

        if (!_settings.ThrowExceptionOnFail)
        {
            var response = Activator.CreateInstance<TResponse>();
            response.Error = errorResponse;
            response.ResponseStatus = Enums.ResponseStatus.ERROR;
            return response;
        }

        throw new SaferPayException(res.StatusCode, errorResponse);
    }


    private TResponse HandleErrorResponse<TResponse>(RestResponse res) where TResponse : Models.Management.RestResponseBase
    {
        // 1. 404 Özel Kontrolü (Genellikle içerik boş döner, bu yüzden manuel mesaj ekliyoruz)
        if (res.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            var notFoundError = new ErrorResponse { ErrorMessage = "Requested resource not found (404)." };
            return ProcessFailure<TResponse>(res.StatusCode, notFoundError);
        }

        // 2. API'den gelen hata içeriğini (JSON) deserialize etmeye çalışıyoruz
        ErrorResponse errorResponse = null;
        if (!string.IsNullOrEmpty(res.Content))
        {
            try
            {
                // Saferpay hata formatına göre (Behavior, ErrorName, ErrorMessage vb.) çözümlüyoruz
                errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(res.Content, _jsonSerializerSettings);
            }
            catch (JsonException)
            {
                // Yanıt JSON formatında değilse veya beklenmedik bir yapıdaysa
                errorResponse = new ErrorResponse { ErrorMessage = $"API Parse Error: {res.Content}" };
            }
        }

        // 3. Eğer içerik boşsa veya deserialization başarısız olduysa RestSharp hata mesajlarını kullanıyoruz
        errorResponse ??= new ErrorResponse
        {
            ErrorMessage = !string.IsNullOrEmpty(res.ErrorMessage) ? res.ErrorMessage : $"Server Exception: {res.StatusCode}"
        };

        return ProcessFailure<TResponse>(res.StatusCode, errorResponse);
    }

    /// <summary>
    /// Ayarlara göre hata fırlatan veya Response nesnesi dönen yardımcı alt metot
    /// </summary>
    private TResponse ProcessFailure<TResponse>(System.Net.HttpStatusCode statusCode, ErrorResponse error) where TResponse : Models.Management.RestResponseBase
    {
        if (_settings.ThrowExceptionOnFail)
        {
            // Gelişmiş bir exception fırlatıyoruz
            throw new SaferPayException(statusCode, error);
        }

        // Exception istenmiyorsa ERROR statusü ile nesne dönüyoruz
        var response = Activator.CreateInstance<TResponse>();
        response.Error = error;
        response.ResponseStatus = Enums.ResponseStatus.ERROR;
        return response;
    }
}
