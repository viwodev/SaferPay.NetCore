using SaferPay.Models.PaymentPage;

namespace SaferPay.Interfaces
{
    /// <summary>
    /// <b>Payment Page</b><br/><br/>
    /// The Payment Page Interface provides a simple and easy integration of Saferpay into your web shop, mobile app or other applications without the need to implement a user interface for card data entry. The Saferpay Payment Page can be used with a Saferpay eCommerce license as well as with a Saferpay Business license. It allows the processing of all payment methods that are available with Saferpay. Once integrated, more payment methods can be activated at any time and without major adjustments.<br/><br/>
    /// https://saferpay.github.io/jsonapi/index.html#ChapterPaymentPage
    /// </summary>
    public interface IPaymentPage
    {
        #region Sync Methods
        /// <summary>
        /// <b>Initialize</b><br/><br/>
        /// This method can be used to start a transaction with the Payment Page which may involve either DCC and / or 3d-secure
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public InitializePaymentPageResponse Initialize(InitializePaymentPageRequest request);

        /// <summary>
        /// <b>Assert</b><br/><br/>
        /// Call this function to safely check the status of the transaction from your server.<br/><br/>
        /// <i><b>Important:</b></i><br/><br/>
        /// <i>
        /// * Depending on the payment provider, the resulting transaction may either be an authorization or may already be captured (meaning the financial flow was already triggered). This will be visible in the status of the transaction container returned in the response.<br/>
        /// * This function can be called up to 24 hours after the transaction was initialized.<br/>
        /// * If the transaction failed (the payer was redirected to the Fail url or he manipulated the return url), an error response with an http status code 400 or higher containing an error message will be returned providing some information on the transaction failure.<br/>
        /// </i>
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public AssertResponse Assert(AssertRequest request);
        #endregion

        #region Async Methods
        /// <summary>
        /// <b>Initialize</b><br/><br/>
        /// This method can be used to start a transaction with the Payment Page which may involve either DCC and / or 3d-secure
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<InitializePaymentPageResponse> InitializeAsync(InitializePaymentPageRequest request);

        /// <summary>
        /// <b>Assert</b><br/><br/>
        /// Call this function to safely check the status of the transaction from your server.<br/><br/>
        /// <i><b>Important:</b></i><br/><br/>
        /// <i>
        /// * Depending on the payment provider, the resulting transaction may either be an authorization or may already be captured (meaning the financial flow was already triggered). This will be visible in the status of the transaction container returned in the response.<br/>
        /// * This function can be called up to 24 hours after the transaction was initialized.<br/>
        /// * If the transaction failed (the payer was redirected to the Fail url or he manipulated the return url), an error response with an http status code 400 or higher containing an error message will be returned providing some information on the transaction failure.<br/>
        /// </i>
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<AssertResponse> AssertAsync(AssertRequest request);
        #endregion
    }
}
