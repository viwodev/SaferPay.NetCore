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

    private RestClient BuildClient(Uri uri)
    {
        var opt = new RestClientOptions(uri)
        {
            Authenticator = new HttpBasicAuthenticator(_settings.Username, _settings.Password)
        };
        return new RestClient(opt);
    }

    private static void AddManagementHeaders(RestRequest req)
    {
        req.AddHeader("Saferpay-ApiVersion", SaferPayApiConstants.Version);
        req.AddHeader("Saferpay-RequestId", Guid.NewGuid().ToString());
        req.AddHeader("Content-Type", "application/json; charset=utf-8");
        req.AddHeader("Accept", "application/json");
    }

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

            using var client = BuildClient(uri);
            var req = new RestRequest { Method = Method.Post };

            var json = request.Json();
            req.AddParameter("application/json", json, ParameterType.RequestBody);

            var res = await client.ExecuteAsync(req);
            if (res != null && res.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var response = JsonConvert.DeserializeObject<TResponse>(res.Content!, _jsonSerializerSettings);
                response!.ResponseStatus = Enums.ResponseStatus.SUCCESS;
                return response;
            }

            return HandleSendErrorResponse<TResponse>(res);
        }
        catch (Exception ex)
        {
            if (_settings.ThrowExceptionOnFail) throw;
            return ProcessSendFailure<TResponse>(default, new ErrorResponse { ErrorMessage = ex.Message });
        }
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
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

        using var client = BuildClient(uri);
        var req = new RestRequest { Method = Method.Post };

        var json = request.Json();
        req.AddParameter("application/json", json, ParameterType.RequestBody);

        var res = client.Execute(req);
        if (res != null && res.StatusCode == System.Net.HttpStatusCode.OK)
        {
            var response = JsonConvert.DeserializeObject<TResponse>(res.Content!, _jsonSerializerSettings);
            response!.ResponseStatus = Enums.ResponseStatus.SUCCESS;
            return response;
        }

        return HandleSendErrorResponse<TResponse>(res);
    }

    public TResponse Get<TResponse>(string path) where TResponse : Models.Management.RestResponseBase
    {
        return GetAsync<TResponse>(path).GetAwaiter().GetResult();
    }

    public async Task<TResponse> GetAsync<TResponse>(string path) where TResponse : Models.Management.RestResponseBase
    {
        var uri = new Uri(_settings.BaseUri, path);
        using var client = BuildClient(uri);

        var req = new RestRequest { Method = Method.Get };
        AddManagementHeaders(req);

        var res = await client.ExecuteAsync(req);

        if (res.IsSuccessful && res.StatusCode == System.Net.HttpStatusCode.OK)
        {
            var response = JsonConvert.DeserializeObject<TResponse>(res.Content ?? "{}", _jsonSerializerSettings);
            if (response != null)
            {
                response.ResponseStatus = Enums.ResponseStatus.SUCCESS;
                return response;
            }
        }

        return HandleErrorResponse<TResponse>(res);
    }

    public TResponse Get<TResponse, TRequest>(string path, TRequest request)
        where TResponse : Models.Management.RestResponseBase
        where TRequest : RestRequestBase
    {
        return GetAsync<TResponse, TRequest>(path, request).GetAwaiter().GetResult();
    }

    public async Task<TResponse> GetAsync<TResponse, TRequest>(string path, TRequest request)
        where TResponse : Models.Management.RestResponseBase
        where TRequest : RestRequestBase
    {
        using var client = BuildClient(_settings.BaseUri);

        var req = new RestRequest(path, Method.Get);

        // Query parameters
        if (request != null)
        {
            var properties = typeof(TRequest).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in properties)
            {
                if (Attribute.IsDefined(prop, typeof(JsonIgnoreAttribute)))
                    continue;

                var jsonProperty = prop.GetCustomAttribute<JsonPropertyAttribute>();
                string paramName = jsonProperty != null ? jsonProperty.PropertyName : prop.Name;

                var value = prop.GetValue(request);
                if (value == null) continue;

                if (prop.PropertyType.IsEnum || (Nullable.GetUnderlyingType(prop.PropertyType)?.IsEnum == true))
                {
                    req.AddQueryParameter(paramName, value.ToString());
                }
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

        AddManagementHeaders(req);

        var res = await client.ExecuteAsync(req);

        if (res.IsSuccessful && res.StatusCode == System.Net.HttpStatusCode.OK)
        {
            var response = JsonConvert.DeserializeObject<TResponse>(res.Content ?? "{}", _jsonSerializerSettings);
            if (response != null)
            {
                response.ResponseStatus = Enums.ResponseStatus.SUCCESS;
                return response;
            }
        }

        return HandleErrorResponse<TResponse>(res);
    }

    public TResponse Post<TResponse>(string path) where TResponse : Models.Management.RestResponseBase
    {
        return PostAsync<TResponse>(path).GetAwaiter().GetResult();
    }

    public async Task<TResponse> PostAsync<TResponse>(string path) where TResponse : Models.Management.RestResponseBase
    {
        var uri = new Uri(_settings.BaseUri, path);
        using var client = BuildClient(uri);

        var req = new RestRequest { Method = Method.Post };
        AddManagementHeaders(req);

        var res = await client.ExecuteAsync(req);

        if (res.IsSuccessful && res.StatusCode == System.Net.HttpStatusCode.OK)
        {
            var response = JsonConvert.DeserializeObject<TResponse>(res.Content ?? "{}", _jsonSerializerSettings);
            if (response != null)
            {
                response.ResponseStatus = Enums.ResponseStatus.SUCCESS;
                return response;
            }
        }

        return HandleErrorResponse<TResponse>(res);
    }

    public TResponse Post<TResponse, TRequest>(string path, TRequest request)
        where TResponse : Models.Management.RestResponseBase
        where TRequest : RestRequestBase
    {
        return PostAsync<TResponse, TRequest>(path, request).GetAwaiter().GetResult();
    }

    public async Task<TResponse> PostAsync<TResponse, TRequest>(string path, TRequest request)
        where TResponse : Models.Management.RestResponseBase
        where TRequest : RestRequestBase
    {
        var uri = new Uri(_settings.BaseUri, path);
        using var client = BuildClient(uri);

        var req = new RestRequest { Method = Method.Post };

        var json = request.Json();
        req.AddParameter("application/json", json, ParameterType.RequestBody);

        AddManagementHeaders(req);

        var res = await client.ExecuteAsync(req);

        if (res.IsSuccessful && res.StatusCode == System.Net.HttpStatusCode.OK)
        {
            var response = JsonConvert.DeserializeObject<TResponse>(res.Content ?? "{}", _jsonSerializerSettings);
            if (response != null)
            {
                response.ResponseStatus = Enums.ResponseStatus.SUCCESS;
                return response;
            }
        }

        return HandleErrorResponse<TResponse>(res);
    }

    public TResponse Delete<TResponse>(string path) where TResponse : Models.Management.RestResponseBase
    {
        return DeleteAsync<TResponse>(path).GetAwaiter().GetResult();
    }

    public async Task<TResponse> DeleteAsync<TResponse>(string path) where TResponse : Models.Management.RestResponseBase
    {
        var uri = new Uri(_settings.BaseUri, path);
        using var client = BuildClient(uri);

        var req = new RestRequest(path, Method.Delete);
        AddManagementHeaders(req);

        var res = await client.ExecuteAsync(req);

        // Success (200 OK or 204 No Content)
        if (res.IsSuccessful)
        {
            var content = string.IsNullOrWhiteSpace(res.Content) ? "{}" : res.Content;
            var response = JsonConvert.DeserializeObject<TResponse>(content, _jsonSerializerSettings);

            response ??= Activator.CreateInstance<TResponse>();
            response.ResponseStatus = Enums.ResponseStatus.SUCCESS;
            return response;
        }

        return HandleErrorResponse<TResponse>(res);
    }


    /// <summary>
    /// Build an error response (or throw) for a failed REST (management) call.
    /// </summary>
    private TResponse HandleErrorResponse<TResponse>(RestResponse res) where TResponse : Models.Management.RestResponseBase
    {
        if (res == null)
        {
            return ProcessFailure<TResponse>(default, new ErrorResponse { ErrorMessage = "No response from server." });
        }

        if (res.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            var notFoundError = new ErrorResponse { ErrorMessage = "Requested resource not found (404)." };
            return ProcessFailure<TResponse>(res.StatusCode, notFoundError);
        }

        ErrorResponse errorResponse = null;
        if (!string.IsNullOrEmpty(res.Content))
        {
            try
            {
                errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(res.Content, _jsonSerializerSettings);
            }
            catch (JsonException)
            {
                errorResponse = new ErrorResponse { ErrorMessage = $"API Parse Error: {res.Content}" };
            }
        }

        errorResponse ??= new ErrorResponse
        {
            ErrorMessage = !string.IsNullOrEmpty(res.ErrorMessage) ? res.ErrorMessage : $"Server Exception: {res.StatusCode}"
        };

        return ProcessFailure<TResponse>(res.StatusCode, errorResponse);
    }

    /// <summary>
    /// Throws when ThrowExceptionOnFail is set, otherwise returns an ERROR response instance.
    /// </summary>
    private TResponse ProcessFailure<TResponse>(System.Net.HttpStatusCode statusCode, ErrorResponse error) where TResponse : Models.Management.RestResponseBase
    {
        if (_settings.ThrowExceptionOnFail)
        {
            throw new SaferPayException(statusCode, error);
        }

        var response = Activator.CreateInstance<TResponse>();
        response.Error = error;
        response.ResponseStatus = Enums.ResponseStatus.ERROR;
        return response;
    }

    /// <summary>
    /// Build an error response (or throw) for a failed Send call (Core JSON API).
    /// </summary>
    private TResponse HandleSendErrorResponse<TResponse>(RestResponse res) where TResponse : ResponseBase
    {
        if (res == null)
        {
            return ProcessSendFailure<TResponse>(default, new ErrorResponse { ErrorMessage = "No response from server." });
        }

        ErrorResponse errorResponse = null;
        if (!string.IsNullOrEmpty(res.Content))
        {
            try
            {
                errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(res.Content, _jsonSerializerSettings);
            }
            catch (JsonException)
            {
                errorResponse = new ErrorResponse { ErrorMessage = $"API Parse Error: {res.Content}" };
            }
        }

        errorResponse ??= new ErrorResponse
        {
            ErrorMessage = !string.IsNullOrEmpty(res.ErrorMessage) ? res.ErrorMessage : $"Server Exception: {res.StatusCode}"
        };

        return ProcessSendFailure<TResponse>(res.StatusCode, errorResponse);
    }

    /// <summary>
    /// Throws when ThrowExceptionOnFail is set, otherwise returns an ERROR response instance.
    /// </summary>
    private TResponse ProcessSendFailure<TResponse>(System.Net.HttpStatusCode statusCode, ErrorResponse error) where TResponse : ResponseBase
    {
        if (_settings.ThrowExceptionOnFail)
        {
            throw new SaferPayException(statusCode, error);
        }

        var response = Activator.CreateInstance<TResponse>();
        response.Error = error;
        response.ResponseStatus = Enums.ResponseStatus.ERROR;
        return response;
    }
}
