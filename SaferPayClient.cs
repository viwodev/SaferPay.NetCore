using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using SaferPay.Config;
using SaferPay.Exceptions;
using SaferPay.Interfaces;
using SaferPay.Models.Core;

namespace SaferPay
{

    /// <summary>
    /// SaferPayClient
    /// </summary>
    public class SaferPayClient : ISaferPayClient
    {

        protected readonly SaferPaySettings _settings;
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        public ITransaction Transaction => new SaferPay.Channels.Transaction(this);

        public IPaymentPage PaymentPage => new SaferPay.Channels.PaymentPage(this);

        public ISecureCardData SecureCardData => new SaferPay.Channels.SecureCardData(this);

        public IBatch Batch => new SaferPay.Channels.Batch(this);

        public IOmniChannel OmniChannel => new SaferPay.Channels.OmniChannel(this);

        public SaferPayClient(SaferPaySettings settings) : this(settings, JsonSettings.Default) { }

        public SaferPayClient(string customerId, string terminalId, string userName, string passWord, bool sandBox = false)
        {
            this._settings = new SaferPaySettings(customerId, terminalId, userName, passWord, sandBox);
        }

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

                var client = new RestClient(opt);
                var req = new RestRequest();
                req.Method = Method.Post;

                var json = request.Json();
                req.AddParameter("application/json", json, ParameterType.RequestBody);

                var res = await client.ExecuteAsync(req);
                if (res != null && res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var response = JsonConvert.DeserializeObject<TResponse>(res.Content, _jsonSerializerSettings);
                    response.ResponseStatus = Enums.ResponseStatus.SUCCESS;
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
                    throw spex;
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

                throw ex;

            }

            return null;
        }

        public void Dispose()
        {
            this.Dispose();
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

            var client = new RestClient(opt);
            var req = new RestRequest();
            req.Method = Method.Post;

            var json = request.Json();
            req.AddParameter("application/json", json, ParameterType.RequestBody);

            var res = client.Execute(req);
            if (res != null && res.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var response = JsonConvert.DeserializeObject<TResponse>(res.Content, _jsonSerializerSettings);
                response.ResponseStatus = Enums.ResponseStatus.SUCCESS;
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
    }
}
