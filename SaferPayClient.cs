using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SaferPay.Models;
using RestSharp;
using RestSharp.Authenticators;
using System.Net.Mail;

namespace SaferPay
{
    /// <summary>
    /// SaferPay Client Interface
    /// </summary>
    public interface ISaferPayClient : IDisposable
    {
        /// <summary>
        /// Async Send
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <typeparam name="TRequest"></typeparam>
        /// <param name="path"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<TResponse> SendAsync<TResponse, TRequest>(string path, TRequest request) where TRequest : RequestBase where TResponse : ResponseBase;

        /// <summary>
        /// Sync Send
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <typeparam name="TRequest"></typeparam>
        /// <param name="path"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        TResponse Send<TResponse, TRequest>(string path, TRequest request) where TRequest : RequestBase where TResponse : ResponseBase;
    }

    /// <summary>
    /// SaferPayClient
    /// </summary>
    public class SaferPayClient : ISaferPayClient
    {

        protected readonly SaferPaySettings _settings;
        private readonly JsonSerializerSettings _jsonSerializerSettings;

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

        protected virtual string GenerateRequestId() => Guid.NewGuid().ToString("n");

        protected virtual RequestHeader CreateRequestHeader() => new RequestHeader
        {
            CustomerId = _settings.CustomerId,
            SpecVersion = SaferPayApiConstants.Version,
            RequestId = GenerateRequestId(),
            RetryIndicator = 0
        };

        public virtual async Task<TResponse> SendAsync<TResponse, TRequest>(string path, TRequest request) where TRequest : RequestBase where TResponse : ResponseBase
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            request.RequestHeader = CreateRequestHeader();
            var uri = new Uri(_settings.BaseUri, path);

            var opt = new RestClientOptions(uri);
            opt.Authenticator = new HttpBasicAuthenticator(_settings.Username, _settings.Password);

            var client = new RestClient(opt);
            var req = new RestRequest();
            req.Method = Method.Post;
            req.AddJsonBody(request);
            var res = await client.ExecuteAsync(req);
            if (res != null && res.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<TResponse>(res.Content, _jsonSerializerSettings);
            }
            else
            {
                var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(res.Content, _jsonSerializerSettings);
                throw new SaferPayException(res.StatusCode, errorResponse);
            }
        }

        public void Dispose()
        {
            this.Dispose();
        }

        public TResponse Send<TResponse, TRequest>(string path, TRequest request)
            where TResponse : ResponseBase
            where TRequest : RequestBase
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            request.RequestHeader = CreateRequestHeader();
            var uri = new Uri(_settings.BaseUri, path);

            var opt = new RestClientOptions(uri);
            opt.Authenticator = new HttpBasicAuthenticator(_settings.Username, _settings.Password);

            var client = new RestClient(opt);
            var req = new RestRequest();
            req.Method = Method.Post;
            req.AddJsonBody(request);
            var res = client.Execute(req);
            if (res != null && res.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<TResponse>(res.Content, _jsonSerializerSettings);
            }
            else
            {
                var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(res.Content, _jsonSerializerSettings);
                throw new SaferPayException(res.StatusCode, errorResponse);
            }
        }
    }
}
