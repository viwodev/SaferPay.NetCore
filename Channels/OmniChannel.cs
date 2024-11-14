using SaferPay.Config;
using SaferPay.Interfaces;
using SaferPay.Models.Core;
using SaferPay.Models.OmniChannel;

namespace SaferPay.Channels;

/// <summary>
/// Omni Channel
/// </summary>
public class OmniChannel : IOmniChannel
{

    private readonly ISaferPayClient _client;

    public OmniChannel(SaferPaySettings settings) => _client = new SaferPayClient(settings);
    public OmniChannel(ISaferPayClient client) => _client = client;
    public OmniChannel(string customerId, string terminalId, string userName, string passWord, bool sandBox = false) => _client = new SaferPayClient(new SaferPaySettings(customerId, terminalId, userName, passWord, sandBox));


    public AcquireTransactionResponse AcquireTransaction(AcquireTransactionRequest request)
    {
        if (_client != null) return _client.Send<AcquireTransactionResponse, AcquireTransactionRequest>(SaferPayEndpoints.OmniChannelEndpoint + SaferPayMethods.OmniChannelAcquireTransaction, request);
        return null;
    }

    public Task<AcquireTransactionResponse> AcquireTransactionAsync(AcquireTransactionRequest request)
    {
        if (_client != null) return _client.SendAsync<AcquireTransactionResponse, AcquireTransactionRequest>(SaferPayEndpoints.OmniChannelEndpoint + SaferPayMethods.OmniChannelAcquireTransaction, request);
        return null;
    }

    public InsertAliasResponse InsertAlias(InsertAliasRequest request)
    {
        if (_client != null) return _client.Send<InsertAliasResponse, InsertAliasRequest>(SaferPayEndpoints.OmniChannelEndpoint + SaferPayMethods.OmniChannelInsertAlias, request);
        return null;
    }

    public Task<InsertAliasResponse> InsertAliasAsync(InsertAliasRequest request)
    {
        if (_client != null) return _client.SendAsync<InsertAliasResponse, InsertAliasRequest>(SaferPayEndpoints.OmniChannelEndpoint + SaferPayMethods.OmniChannelInsertAlias, request);
        return null;
    }
}
