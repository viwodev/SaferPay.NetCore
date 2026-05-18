using SaferPay.Config;
using SaferPay.Interfaces;
using SaferPay.Models.Core;
using SaferPay.Models.SecureData;

namespace SaferPay.Channels;

public class SecureCardData : ISecureCardData
{
    private readonly ISaferPayClient _client;

    public SecureCardData(SaferPaySettings settings) => _client = new SaferPayClient(settings);
    public SecureCardData(ISaferPayClient client) => _client = client ?? throw new ArgumentNullException(nameof(client));
    public SecureCardData(string customerId, string terminalId, string userName, string passWord, bool sandBox = false)
        => _client = new SaferPayClient(new SaferPaySettings(customerId, terminalId, userName, passWord, sandBox));

    public AliasDeleteResponse AliasDelete(AliasDeleteRequest request) =>
        _client.Send<AliasDeleteResponse, AliasDeleteRequest>(SaferPayEndpoints.AliasEndpoint + SaferPayMethods.AliasDelete, request);

    public Task<AliasDeleteResponse> AliasDeleteAsync(AliasDeleteRequest request) =>
        _client.SendAsync<AliasDeleteResponse, AliasDeleteRequest>(SaferPayEndpoints.AliasEndpoint + SaferPayMethods.AliasDelete, request);

    public AliasInquireResponse AliasInquire(AliasInquireRequest request) =>
        _client.Send<AliasInquireResponse, AliasInquireRequest>(SaferPayEndpoints.AliasEndpoint + SaferPayMethods.AliasInquire, request);

    public Task<AliasInquireResponse> AliasInquireAsync(AliasInquireRequest request) =>
        _client.SendAsync<AliasInquireResponse, AliasInquireRequest>(SaferPayEndpoints.AliasEndpoint + SaferPayMethods.AliasInquire, request);

    public AliasInsertResponse AliasInsert(AliasInsertRequest request) =>
        _client.Send<AliasInsertResponse, AliasInsertRequest>(SaferPayEndpoints.AliasEndpoint + SaferPayMethods.AliasInsert, request);

    public Task<AliasInsertResponse> AliasInsertAsync(AliasInsertRequest request) =>
        _client.SendAsync<AliasInsertResponse, AliasInsertRequest>(SaferPayEndpoints.AliasEndpoint + SaferPayMethods.AliasInsert, request);

    public AliasUpdateResponse AliasUpdate(AliasUpdateRequest request) =>
        _client.Send<AliasUpdateResponse, AliasUpdateRequest>(SaferPayEndpoints.AliasEndpoint + SaferPayMethods.AliasUpdate, request);

    public Task<AliasUpdateResponse> AliasUpdateAsync(AliasUpdateRequest request) =>
        _client.SendAsync<AliasUpdateResponse, AliasUpdateRequest>(SaferPayEndpoints.AliasEndpoint + SaferPayMethods.AliasUpdate, request);

    public AssertInsertResponse AssertInsert(AssertInsertRequest request) =>
        _client.Send<AssertInsertResponse, AssertInsertRequest>(SaferPayEndpoints.AliasEndpoint + SaferPayMethods.AliasAssertInsert, request);

    public Task<AssertInsertResponse> AssertInsertAsync(AssertInsertRequest request) =>
        _client.SendAsync<AssertInsertResponse, AssertInsertRequest>(SaferPayEndpoints.AliasEndpoint + SaferPayMethods.AliasAssertInsert, request);

    public InsertDirectResponse InsertDirect(InsertDirectRequest request) =>
        _client.Send<InsertDirectResponse, InsertDirectRequest>(SaferPayEndpoints.AliasEndpoint + SaferPayMethods.AliasInsertDirect, request);

    public Task<InsertDirectResponse> InsertDirectAsync(InsertDirectRequest request) =>
        _client.SendAsync<InsertDirectResponse, InsertDirectRequest>(SaferPayEndpoints.AliasEndpoint + SaferPayMethods.AliasInsertDirect, request);
}
