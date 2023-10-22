using SaferPay.Config;
using SaferPay.Interfaces;
using SaferPay.Models.Core;
using SaferPay.Models.PaymentPage;

namespace SaferPay.Channels
{

    /// <summary>
    /// <b>Payment Page</b><br/><br/>
    /// The Payment Page Interface provides a simple and easy integration of Saferpay into your web shop, mobile app or other applications without the need to implement a user interface for card data entry. The Saferpay Payment Page can be used with a Saferpay eCommerce license as well as with a Saferpay Business license. It allows the processing of all payment methods that are available with Saferpay. Once integrated, more payment methods can be activated at any time and without major adjustments.
    /// </summary>
    public class PaymentPage : IPaymentPage
    {

        private readonly ISaferPayClient _client;


        public PaymentPage(SaferPaySettings settings) => _client = new SaferPayClient(settings);
        public PaymentPage(ISaferPayClient client) => _client = client;
        public PaymentPage(string customerId, string terminalId, string userName, string passWord, bool sandBox = false) => _client = new SaferPayClient(new SaferPaySettings(customerId, terminalId, userName, passWord, sandBox));


        public AssertResponse Assert(AssertRequest request)
        {
            if (_client != null) return _client.Send<AssertResponse, AssertRequest>(SaferPayEndpoints.PaymentPageEndpoint + SaferPayMethods.PaymentPageAssert, request);
            return null;
        }

        public Task<AssertResponse> AssertAsync(AssertRequest request)
        {
            if (_client != null) return _client.SendAsync<AssertResponse, AssertRequest>(SaferPayEndpoints.PaymentPageEndpoint + SaferPayMethods.PaymentPageAssert, request);
            return null;
        }

        public InitializePaymentPageResponse Initialize(InitializePaymentPageRequest request)
        {
            if (_client != null) return _client.Send<InitializePaymentPageResponse, InitializePaymentPageRequest>(SaferPayEndpoints.PaymentPageEndpoint + SaferPayMethods.PaymentPageInitialize, request);
            return null;
        }

        public Task<InitializePaymentPageResponse> InitializeAsync(InitializePaymentPageRequest request)
        {
            if (_client != null) return _client.SendAsync<InitializePaymentPageResponse, InitializePaymentPageRequest>(SaferPayEndpoints.PaymentPageEndpoint + SaferPayMethods.PaymentPageInitialize, request);
            return null;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
