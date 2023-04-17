using System;
using System.Text.RegularExpressions;

namespace SaferPay.Models
{
	public class Transaction
	{

        /// <summary>
        /// Type of transaction. One of 'PAYMENT'<br/><br/>
        /// <strong>Mandatory</strong>
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Current status of the transaction. One of 'AUTHORIZED','CANCELED', 'CAPTURED' or 'PENDING' (PENDING is only used for paydirekt and WL Crypto Payments refund at the moment)<br/><br/>
        /// <strong>Mandatory</strong>
        /// </summary>
        public TransactionStatus Status { get; set; }

        /// <summary>
        /// Unique Saferpay transaction id. Used to reference the transaction in any further step.<br/><br/>
        /// <i>Example: K5OYS9Ad6Ex4rASU1IM1b3CEU8bb</i><br/>
        /// <strong>Mandatory</strong>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Unique Saferpay capture id.<br/>
        /// Available if the transaction was already captured(Status: CAPTURED).<br/>
        /// Must be stored for later reference(eg refund).<br/><br/>
        /// <i>Id[1..64]<br/>
        /// Example: ECthWpbv1SI6SAIdU2p6AIC1bppA</i>
        /// </summary>
        public string CaptureId { get; set; }

        /// <summary>
        /// Date / time of the authorization<br/><br/>
        /// <strong>Mandatory</strong>
        /// </summary>
        public DateTimeOffset Date { get; set; }

        /// <summary>
        /// Amount (currency, value, etc.) that has been authorized.<br/><br/>
        /// <strong>Mandatory</strong>
        /// </summary>
		public Amount Amount { get; set; }

        /// <summary>
        /// OrderId given with request<br/><br/>
        /// <i>Id[1..80]<br/>
        /// Example: c52ad18472354511ab2c33b59e796901</i>
        /// </summary>
		public string OrderId { get; set; }

        /// <summary>
        /// Name of the acquirer<br/><br/>
        /// <i>Example: AcquirerName</i>
        /// </summary>
		public string AcquireName { get; set; }

        /// <summary>
        /// Reference id of the acquirer (if available)<br/><br/>
        /// <i>Example: AcquirerReference</i>
        /// </summary>
		public string AcquirerReference { get; set; }

        /// <summary>
        /// Unique SIX transaction reference.<br/><br/>
        /// <i>Example: 0:0:3:K5OYS9Ad6Ex4rASU1IM1b3CEU8bb</i><br/>
        /// <strong>Mandatory</strong>
        /// </summary>
        public string SixTransactionReference { get; set; }

        /// <summary>
        /// Approval id of the acquirer (if available)<br/><br/>
        /// <i>Example: AcquirerReference</i>
        /// </summary>
        public string ApprovalCode { get; set; }

        /// <summary>
        /// Direct Debit information, if applicable
        /// </summary>
        public DirectDebitResponse DirectDebit { get; set; }
	}

    public enum TransactionStatus
    {
        AUTHORIZED,
        CANCELED,
        CAPTURED,
        PENDING
    }
}