namespace SaferPay.Config
{

    public static class SaferPayMethods
    {
        /// <summary>
        /// Request URL:        POST: /Payment/v1/Transaction/Initialize
        /// </summary>
        public const string TransactionInitialize = "Initialize";

        /// <summary>
        /// Request URL:        POST: /Payment/v1/Transaction/Authorize
        /// </summary>
        public const string TransactionAuthorize = "Authorize";

        /// <summary>
        /// Request URL:        POST: /Payment/v1/Transaction/QueryPaymentMeans
        /// </summary>
        public const string TransactionQueryPaymentMeans = "QueryPaymentMeans";

        /// <summary>
        /// Request URL:        POST: /Payment/v1/Transaction/AdjustAmount
        /// </summary>
        public const string TransactionAdjustAmount = "AdjustAmount";

        /// <summary>
        /// Request URL:        POST: /Payment/v1/Transaction/AuthorizeDirect
        /// </summary>
        public const string TransactionAuthorizeDirect = "AuthorizeDirect";

        /// <summary>
        /// Request URL:        POST: /Payment/v1/Transaction/AuthorizeReferenced
        /// </summary>
        public const string TransactionAuthorizeReferenced = "AuthorizeReferenced";

        /// <summary>
        /// Request URL:        POST: /Payment/v1/Transaction/Capture
        /// </summary>
        public const string TransactionCapture = "Capture";

        /// <summary>
        /// Request URL:        POST: /Payment/v1/Transaction/MultipartCapture
        /// </summary>
        public const string TransactionMultipartCapture = "MultipartCapture";

        /// <summary>
        /// Request URL:        POST: /Payment/v1/Transaction/AssertCapture
        /// </summary>
        public const string TransactionAssertCapture = "AssertCapture";

        /// <summary>
        /// Request URL:        POST: /Payment/v1/Transaction/MultipartFinalize
        /// </summary>
        public const string TransactionMultipartFinalize = "MultipartFinalize";

        /// <summary>
        /// Request URL:        POST: /Payment/v1/Transaction/Refund
        /// </summary>
        public const string TransactionRefund = "Refund";

        /// <summary>
        /// Request URL:        POST: /Payment/v1/Transaction/AssertRefund
        /// </summary>
        public const string TransactionAssertRefund = "AssertRefund";

        /// <summary>
        /// Request URL:        POST: /Payment/v1/Transaction/RefundDirect
        /// </summary>
        public const string TransactionRefundDirect = "RefundDirect";

        /// <summary>
        /// Request URL:        POST: /Payment/v1/Transaction/Cancel
        /// </summary>
        public const string TransactionCancel = "Cancel";

        /// <summary>
        /// Request URL:        POST: /Payment/v1/Transaction/RedirectPayment
        /// </summary>
        public const string TransactionRedirectPayment = "RedirectPayment";

        /// <summary>
        /// Request URL:        POST: /Payment/v1/Transaction/AssertRedirectPayment
        /// </summary>
        public const string TransactionAssertRedirectPayment = "AssertRedirectPayment";

        /// <summary>
        /// Request URL:        POST: /Payment/v1/Transaction/Inquire
        /// </summary>
        public const string TransactionInquire = "Inquire";

        /// <summary>
        /// Request URL:        POST: /Payment/v1/Transaction/AlternativePayment
        /// </summary>
        public const string TransactionAlternativePayment = "AlternativePayment";

        /// <summary>
        /// Request URL:        POST: /Payment/v1/Transaction/QueryAlternativePayment
        /// </summary>
        public const string TransactionQueryAlternativePayment = "QueryAlternativePayment";

        /// <summary>
        /// Request URL:        POST: /Payment/v1/PaymentPage/Initialize
        /// </summary>
        public const string PaymentPageInitialize = "Initialize";

        /// <summary>
        /// Request URL:        POST: /Payment/v1/PaymentPage/Assert
        /// </summary>
        public const string PaymentPageAssert = "Assert";

        /// <summary>
        /// Request URL:        POST: /Payment/v1/Alias/Insert
        /// </summary>
        public const string AliasInsert = "Insert";

        /// <summary>
        /// Request URL:        POST: /Payment/v1/Alias/AssertInsert
        /// </summary>
        public const string AliasAssertInsert = "AssertInsert";

        /// <summary>
        /// Request URL:        POST: /Payment/v1/Alias/InsertDirect
        /// </summary>
        public const string AliasInsertDirect = "InsertDirect";

        /// <summary>
        /// Request URL:        POST: /Payment/v1/Alias/Update
        /// </summary>
        public const string AliasUpdate = "Update";

        /// <summary>
        /// Request URL:        POST: /Payment/v1/Alias/Delete
        /// </summary>
        public const string AliasDelete = "Delete";

        /// <summary>
        /// Request URL:        POST: /Payment/v1/Batch/Close
        /// </summary>
        public const string BatchClose = "Close";

        /// <summary>
        /// Request URL:        POST: /Payment/v1/OmniChannel/InsertAlias
        /// </summary>
        public const string OmniChannelInsertAlias = "InsertAlias";

        /// <summary>
        /// Request URL:        POST: /Payment/v1/OmniChannel/AcquireTransaction
        /// </summary>
        public const string OmniChannelAcquireTransaction = "AcquireTransaction";
    }
}