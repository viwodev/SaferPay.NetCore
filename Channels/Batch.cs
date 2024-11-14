using SaferPay.Config;
using SaferPay.Interfaces;
using SaferPay.Models.Batch;
using SaferPay.Models.Core;

namespace SaferPay.Channels;

public class Batch : IBatch
{

    private readonly ISaferPayClient _client;

    public Batch(SaferPaySettings settings) => _client = new SaferPayClient(settings);
    public Batch(ISaferPayClient client) => _client = client;
    public Batch(string customerId, string terminalId, string userName, string passWord, bool sandBox = false) => _client = new SaferPayClient(new SaferPaySettings(customerId, terminalId, userName, passWord, sandBox));


    public BatchResponse Close(BatchRequest request)
    {
        if (_client != null) return _client.Send<BatchResponse, BatchRequest>(SaferPayEndpoints.BatchEndpoint + SaferPayMethods.BatchClose, request);
        return null;
    }

    public Task<BatchResponse> CloseAsync(BatchRequest request)
    {
        if (_client != null) return _client.SendAsync<BatchResponse, BatchRequest>(SaferPayEndpoints.BatchEndpoint + SaferPayMethods.BatchClose, request);
        return null;
    }
}
