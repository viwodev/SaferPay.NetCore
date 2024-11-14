using SaferPay.Models.Transaction;

namespace SaferPay.Interfaces;

/// <summary>
/// Transaction Interface With Sync/Async Calls<br/><br/>
/// https://saferpay.github.io/jsonapi/index.html#ChapterTransaction
/// </summary>
public interface ITransaction
{
    #region Sync Methods
    /// <summary>
    /// <b>Initialize</b><br/><br/>
    /// This method may be used to start a transaction which may involve either DCC and / or 3d-secure.<br/><br/>
    /// <i><b>Warning: </b>Only PCI certified merchants may submit the card-data directly, or use their own HTML form! Click here for more information!</i>
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public InitializeResponse Initialize(InitializeRequest request);


    /// <summary>
    /// <b>Authorize</b><br/><br/>
    /// This function may be called to authorize a transaction which was started by a call to Transaction/Initialize.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public AuthorizeResponse Authorize(AuthorizeRequest request);


    /// <summary>
    /// <b>AuthorizeDirect</b><br/><br/>
    /// This function may be used to directly authorize transactions which do not require a redirect of the customer (e.g. direct debit or recurring transactions based on a previously registered alias).<br/><br/>
    /// <i><b>Warning: </b>Only PCI certified merchants may submit the card-data directly, or use their own HTML form! Click here for more information!</i><br/>
    /// <i><b>Important: </b>This function does not perform 3D Secure! Only the PaymentPage or Transaction Initialize do support 3D Secure!</i>
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public AuthorizeDirectResponse AuthorizeDirect(AuthorizeDirectRequest request);


    /// <summary>
    /// <b>AuthorizeReferenced</b><br/><br/>
    /// This method may be used to perform follow-up authorizations to an earlier transaction. At this time, the referenced (initial) transaction must have been performed setting either the recurring or installment option.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public AuthorizeReferencedResponse AuthorizeReferenced(AuthorizeReferencedRequest request);


    /// <summary>
    /// <b>Capture</b><br/><br/>
    /// This method may be used to finalize previously authorized transactions and refunds.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public CaptureResponse Capture(CaptureRequest request);


    /// <summary>
    /// <b>MultipartCapture</b><br/><br/>
    /// This method may be used to capture multiple parts of an authorized transaction.<br/><br/>
    /// <i>
    /// * MultipartCapture is available for PayPal, Klarna and card payments Visa, Mastercard, Maestro, Diners/Discover, JCB and American Express which are acquired by Worldline.<br/>
    /// * No MultipartCapture request should be sent before receiving the response of a preceding request (i.e. no parallel calls are allowed).<br/>
    /// * The sum of multipart captures must not exceed the authorized amount.<br/>
    /// * A unique OrderPartId must be used for each request.
    /// </i>
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public MultipartCaptureResponse MultipartCapture(MultipartCaptureRequest request);


    /// <summary>
    /// <b>AssertCapture</b><br/><br/>
    /// <i><b>Attention: </b>This method is only supported for pending captures. A pending capture is only applicable for paydirekt transactions at the moment.</i>
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public AssertCaptureResponse AssertCapture(AssertCaptureRequest request);

    /// <summary>
    /// <b>MultipartFinalize</b><br/><br/>
    /// This method may be used to finalize a transaction having one or more partial captures (i.e. marks the end of partial captures).
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public MultipartFinalizeResponse MultipartFinalize(MultipartFinalizeRequest request);


    /// <summary>
    /// <b>Refund</b><br/><br/>
    /// This method may be called to refund a previous transaction.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public RefundResponse Refund(RefundRequest request);


    /// <summary>
    /// <b>AssertRefund</b><br/><br/>
    /// This method may be used to inquire the status and further information of pending refunds.<br/><br/>
    /// <i><b>Attention: </b>This method is only supported for pending refunds. A pending refund is only applicable for paydirekt transactions at the moment.</i>
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public AssertRefundResponse AssertRefund(AssertRefundRequest request);


    /// <summary>
    /// <b>RefundDirect</b><br/><br/>
    /// This method may be called to refund an amount to the given means of payment (not supported for all means of payment) without referencing a previous transaction. This might be the case if the original transaction was done with a card which is not valid any more.
    /// <br/><br/>
    /// <i><b>Warning: </b>Only PCI certified merchants may submit the card-data directly, or use their own HTML form! Click here for more information!</i>
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public RefundDirectResponse RefundDirect(RefundDirectRequest request);


    /// <summary>
    /// <b>Cancel</b><br/><br/>
    /// This method may be used to cancel previously authorized transactions and refunds.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public CancelResponse Cancel(CancelRequest request);


    /// <summary>
    /// <b>RedirectPayment</b><br/><br/>
    /// <i><b>Warning: </b>This feature is deprecated and replaced by the <b>Payment Page</b>. Please use the parameter <b>PaymentMethods</b> to directly select the desired 3rd party provider!</i>
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [Obsolete(message: "This feature is deprecated and replaced by the Payment Page. Please use the parameter PaymentMethods to directly select the desired 3rd party provider!")]
    public RedirectPaymentResponse RedirectPayment(RedirectPaymentRequest request);


    /// <summary>
    /// <b>AssertRedirectPayment</b><br/><br/>
    /// <i><b>Warning: </b>This feature is deprecated and replaced by the <b>Payment Page</b>. Please use the parameter <b>PaymentMethods</b> to directly select the desired 3rd party provider!</i>
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [Obsolete(message: "This feature is deprecated and replaced by the Payment Page. Please use the parameter PaymentMethods to directly select the desired 3rd party provider!")]
    public AssertRedirectPaymentResponse AssertRedirectPayment(AssertRedirectPaymentRequest request);


    /// <summary>
    /// <b>Inquire</b><br/><br/>
    /// This method can be used to get the details of a transaction that has been authorized successfully.
    /// <br/><br/>
    /// <i><b>Fair use: </b>This method is not intended for polling. You have to restrict the usage of this method in order to provide a fair data access to all our customers. We may contact you if we notice the excessive usage of this function and in some exceptional cases we preserve the right to limit the access to it.</i>
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public InquireResponse Inquire(InquireRequest request);


    /// <summary>
    /// <b>AlternativePayment</b><br/><br/>
    /// This method can be used to authorize the payments that do not have a payment-page or for the payments that before authorization some additional steps such as authentication should be done.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public AlternativePaymentResponse AlternativePayment(AlternativePaymentRequest request);


    /// <summary>
    /// <b>QueryAlternativePayment</b><br/><br/>
    /// Call this method to get information about a previously initialized alternative payment transaction
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public QueryAlternativePaymentResponse QueryAlternativePayment(QueryAlternativePaymentRequest request);
    #endregion

    #region Async Methods
    /// <summary>
    /// <b>Initialize</b><br/><br/>
    /// This method may be used to start a transaction which may involve either DCC and / or 3d-secure.<br/><br/>
    /// <i><b>Warning: </b>Only PCI certified merchants may submit the card-data directly, or use their own HTML form! Click here for more information!</i>
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public Task<InitializeResponse> InitializeAsync(InitializeRequest request);


    /// <summary>
    /// <b>Authorize</b><br/><br/>
    /// This function may be called to authorize a transaction which was started by a call to Transaction/Initialize.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public Task<AuthorizeResponse> AuthorizeAsync(AuthorizeRequest request);


    /// <summary>
    /// <b>AuthorizeDirect</b><br/><br/>
    /// This function may be used to directly authorize transactions which do not require a redirect of the customer (e.g. direct debit or recurring transactions based on a previously registered alias).<br/><br/>
    /// <i><b>Warning: </b>Only PCI certified merchants may submit the card-data directly, or use their own HTML form! Click here for more information!</i><br/>
    /// <i><b>Important: </b>This function does not perform 3D Secure! Only the PaymentPage or Transaction Initialize do support 3D Secure!</i>
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public Task<AuthorizeDirectResponse> AuthorizeDirectAsync(AuthorizeDirectRequest request);


    /// <summary>
    /// <b>AuthorizeReferenced</b><br/><br/>
    /// This method may be used to perform follow-up authorizations to an earlier transaction. At this time, the referenced (initial) transaction must have been performed setting either the recurring or installment option.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public Task<AuthorizeReferencedResponse> AuthorizeReferencedAsync(AuthorizeReferencedRequest request);


    /// <summary>
    /// <b>Capture</b><br/><br/>
    /// This method may be used to finalize previously authorized transactions and refunds.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public Task<CaptureResponse> CaptureAsync(CaptureRequest request);


    /// <summary>
    /// <b>MultipartCapture</b><br/><br/>
    /// This method may be used to capture multiple parts of an authorized transaction.<br/><br/>
    /// <i>
    /// * MultipartCapture is available for PayPal, Klarna and card payments Visa, Mastercard, Maestro, Diners/Discover, JCB and American Express which are acquired by Worldline.<br/>
    /// * No MultipartCapture request should be sent before receiving the response of a preceding request (i.e. no parallel calls are allowed).<br/>
    /// * The sum of multipart captures must not exceed the authorized amount.<br/>
    /// * A unique OrderPartId must be used for each request.
    /// </i>
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public Task<MultipartCaptureResponse> MultipartCaptureAsync(MultipartCaptureRequest request);


    /// <summary>
    /// <b>AssertCapture</b><br/><br/>
    /// <i><b>Attention: </b>This method is only supported for pending captures. A pending capture is only applicable for paydirekt transactions at the moment.</i>
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public Task<AssertCaptureResponse> AssertCaptureAsync(AssertCaptureRequest request);

    /// <summary>
    /// <b>MultipartFinalize</b><br/><br/>
    /// This method may be used to finalize a transaction having one or more partial captures (i.e. marks the end of partial captures).
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public Task<MultipartFinalizeResponse> MultipartFinalizeAsync(MultipartFinalizeRequest request);


    /// <summary>
    /// <b>Refund</b><br/><br/>
    /// This method may be called to refund a previous transaction.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public Task<RefundResponse> RefundAsync(RefundRequest request);


    /// <summary>
    /// <b>AssertRefund</b><br/><br/>
    /// This method may be used to inquire the status and further information of pending refunds.<br/><br/>
    /// <i><b>Attention: </b>This method is only supported for pending refunds. A pending refund is only applicable for paydirekt transactions at the moment.</i>
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public Task<AssertRefundResponse> AssertRefundAsync(AssertRefundRequest request);


    /// <summary>
    /// <b>RefundDirect</b><br/><br/>
    /// This method may be called to refund an amount to the given means of payment (not supported for all means of payment) without referencing a previous transaction. This might be the case if the original transaction was done with a card which is not valid any more.
    /// <br/><br/>
    /// <i><b>Warning: </b>Only PCI certified merchants may submit the card-data directly, or use their own HTML form! Click here for more information!</i>
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public Task<RefundDirectResponse> RefundDirectAsync(RefundDirectRequest request);


    /// <summary>
    /// <b>Cancel</b><br/><br/>
    /// This method may be used to cancel previously authorized transactions and refunds.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public Task<CancelResponse> CancelAsync(CancelRequest request);


    /// <summary>
    /// <b>RedirectPayment</b><br/><br/>
    /// <i><b>Warning: </b>This feature is deprecated and replaced by the <b>Payment Page</b>. Please use the parameter <b>PaymentMethods</b> to directly select the desired 3rd party provider!</i>
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [Obsolete(message: "This feature is deprecated and replaced by the Payment Page. Please use the parameter PaymentMethods to directly select the desired 3rd party provider!")]
    public Task<RedirectPaymentResponse> RedirectPaymentAsync(RedirectPaymentRequest request);


    /// <summary>
    /// <b>AssertRedirectPayment</b><br/><br/>
    /// <i><b>Warning: </b>This feature is deprecated and replaced by the <b>Payment Page</b>. Please use the parameter <b>PaymentMethods</b> to directly select the desired 3rd party provider!</i>
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [Obsolete(message: "This feature is deprecated and replaced by the Payment Page. Please use the parameter PaymentMethods to directly select the desired 3rd party provider!")]
    public Task<AssertRedirectPaymentResponse> AssertRedirectPaymentAsync(AssertRedirectPaymentRequest request);


    /// <summary>
    /// <b>Inquire</b><br/><br/>
    /// This method can be used to get the details of a transaction that has been authorized successfully.
    /// <br/><br/>
    /// <i><b>Fair use: </b>This method is not intended for polling. You have to restrict the usage of this method in order to provide a fair data access to all our customers. We may contact you if we notice the excessive usage of this function and in some exceptional cases we preserve the right to limit the access to it.</i>
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public Task<InquireResponse> InquireAsync(InquireRequest request);


    /// <summary>
    /// <b>AlternativePayment</b><br/><br/>
    /// This method can be used to authorize the payments that do not have a payment-page or for the payments that before authorization some additional steps such as authentication should be done.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public Task<AlternativePaymentResponse> AlternativePaymentAsync(AlternativePaymentRequest request);


    /// <summary>
    /// <b>QueryAlternativePayment</b><br/><br/>
    /// Call this method to get information about a previously initialized alternative payment transaction
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public Task<QueryAlternativePaymentResponse> QueryAlternativePaymentAsync(QueryAlternativePaymentRequest request);
    #endregion
}
