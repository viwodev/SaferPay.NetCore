using SaferPay.Interfaces;
using SaferPay.Models.Core;
using SaferPay.Models.Management;

namespace SaferPay.Tests.Unit;

/// <summary>
/// Test double for <see cref="ISaferPayClient"/> that records every
/// Send/SendAsync call's path and request type. Used by channel routing
/// tests to assert that each channel method targets the correct endpoint.
/// </summary>
internal sealed class RecordingSaferPayClient : ISaferPayClient
{
    public readonly List<(string Path, Type RequestType)> Calls = new();

    public string CustomerId => "cust";
    public string TerminalId => "term";

    public ITransaction Transaction => throw new NotImplementedException();
    public IPaymentPage PaymentPage => throw new NotImplementedException();
    public ISecureCardData SecureCardData => throw new NotImplementedException();
    public IBatch Batch => throw new NotImplementedException();
    public IOmniChannel OmniChannel => throw new NotImplementedException();
    public IManagementApi ManagementApi => throw new NotImplementedException();

    public TResponse Send<TResponse, TRequest>(string path, TRequest request)
        where TRequest : RequestBase
        where TResponse : ResponseBase
    {
        Calls.Add((path, typeof(TRequest)));
        return Activator.CreateInstance<TResponse>();
    }

    public Task<TResponse> SendAsync<TResponse, TRequest>(string path, TRequest request)
        where TRequest : RequestBase
        where TResponse : ResponseBase
    {
        Calls.Add((path, typeof(TRequest)));
        return Task.FromResult(Activator.CreateInstance<TResponse>());
    }

    public TResponse Get<TResponse>(string path) where TResponse : RestResponseBase => throw new NotImplementedException();
    public Task<TResponse> GetAsync<TResponse>(string path) where TResponse : RestResponseBase => throw new NotImplementedException();
    public TResponse Get<TResponse, TRequest>(string path, TRequest request) where TRequest : RestRequestBase where TResponse : RestResponseBase => throw new NotImplementedException();
    public Task<TResponse> GetAsync<TResponse, TRequest>(string path, TRequest request) where TRequest : RestRequestBase where TResponse : RestResponseBase => throw new NotImplementedException();
    public TResponse Post<TResponse>(string path) where TResponse : RestResponseBase => throw new NotImplementedException();
    public Task<TResponse> PostAsync<TResponse>(string path) where TResponse : RestResponseBase => throw new NotImplementedException();
    public TResponse Post<TResponse, TRequest>(string path, TRequest request) where TRequest : RestRequestBase where TResponse : RestResponseBase => throw new NotImplementedException();
    public Task<TResponse> PostAsync<TResponse, TRequest>(string path, TRequest request) where TRequest : RestRequestBase where TResponse : RestResponseBase => throw new NotImplementedException();
    public TResponse Delete<TResponse>(string path) where TResponse : RestResponseBase => throw new NotImplementedException();
    public Task<TResponse> DeleteAsync<TResponse>(string path) where TResponse : RestResponseBase => throw new NotImplementedException();

    public void Dispose() { }
}
