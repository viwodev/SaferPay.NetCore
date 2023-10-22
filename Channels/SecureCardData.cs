using SaferPay.Config;
using SaferPay.Interfaces;
using SaferPay.Models.Core;
using SaferPay.Models.SecureData;

namespace SaferPay.Channels
{
    public class SecureCardData : ISecureCardData
    {
        private readonly ISaferPayClient _client;

        public SecureCardData(SaferPaySettings settings) => _client = new SaferPayClient(settings);
        public SecureCardData(ISaferPayClient client) => _client = client;
        public SecureCardData(string customerId, string terminalId, string userName, string passWord, bool sandBox = false) => _client = new SaferPayClient(new SaferPaySettings(customerId, terminalId, userName, passWord, sandBox));

        public AliasDeleteResponse AliasDelete(AliasDeleteRequest request)
        {
            if (_client != null) return _client.Send<AliasDeleteResponse, AliasDeleteRequest>(SaferPayEndpoints.AliasEndpoint + SaferPayMethods.AliasDelete, request);
            return null;
        }

        public Task<AliasDeleteResponse> AliasDeleteAsync(AliasDeleteRequest request)
        {
            if (_client != null) return _client.SendAsync<AliasDeleteResponse, AliasDeleteRequest>(SaferPayEndpoints.AliasEndpoint + SaferPayMethods.AliasDelete, request);
            return null;
        }

        public AliasInsertResponse AliasInsert(AliasInsertRequest request)
        {
            if (_client != null) return _client.Send<AliasInsertResponse, AliasInsertRequest>(SaferPayEndpoints.AliasEndpoint + SaferPayMethods.AliasInsert, request);
            return null;
        }

        public Task<AliasInsertResponse> AliasInsertAsync(AliasInsertRequest request)
        {
            if (_client != null) return _client.SendAsync<AliasInsertResponse, AliasInsertRequest>(SaferPayEndpoints.AliasEndpoint + SaferPayMethods.AliasInsert, request);
            return null;
        }

        public AliasUpdateResponse AliasUpdate(AliasUpdateRequest request)
        {
            if (_client != null) return _client.Send<AliasUpdateResponse, AliasUpdateRequest>(SaferPayEndpoints.AliasEndpoint + SaferPayMethods.AliasUpdate, request);
            return null;
        }

        public Task<AliasUpdateResponse> AliasUpdateAsync(AliasUpdateRequest request)
        {
            if (_client != null) return _client.SendAsync<AliasUpdateResponse, AliasUpdateRequest>(SaferPayEndpoints.AliasEndpoint + SaferPayMethods.AliasUpdate, request);
            return null;
        }

        public AssertInsertResponse AssertInsert(AssertInsertRequest request)
        {
            if (_client != null) return _client.Send<AssertInsertResponse, AssertInsertRequest>(SaferPayEndpoints.AliasEndpoint + SaferPayMethods.AliasAssertInsert, request);
            return null;
        }

        public Task<AssertInsertResponse> AssertInsertAsync(AssertInsertRequest request)
        {
            if (_client != null) return _client.SendAsync<AssertInsertResponse, AssertInsertRequest>(SaferPayEndpoints.AliasEndpoint + SaferPayMethods.AliasAssertInsert, request);
            return null;
        }

        public InsertDirectResponse InsertDirect(InsertDirectRequest request)
        {
            if (_client != null) return _client.Send<InsertDirectResponse, InsertDirectRequest>(SaferPayEndpoints.AliasEndpoint + SaferPayMethods.AliasInsertDirect, request);
            return null;
        }

        public Task<InsertDirectResponse> InsertDirectAsync(InsertDirectRequest request)
        {
            if (_client != null) return _client.SendAsync<InsertDirectResponse, InsertDirectRequest>(SaferPayEndpoints.AliasEndpoint + SaferPayMethods.AliasInsertDirect, request);
            return null;
        }
    }
}
