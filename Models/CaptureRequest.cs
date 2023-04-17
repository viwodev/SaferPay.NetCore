using System.CodeDom;

namespace SaferPay.Models
{
	public class CaptureRequest : RequestBase
	{

        public CaptureRequest()
        {            
        }


        /// <summary>
        /// Reference to authorization.
        /// </summary>
        public TransactionReference TransactionReference { get; set; }

        public CaptureRequest(TransactionReference transactionReference)
        {
            TransactionReference = transactionReference;
        }

        public CaptureRequest(string transactionId)
        {
            this.TransactionReference = new TransactionReference(transactionId);
        }

        /// <summary>
        /// Currency must match the original transaction currency (request will be declined if currency does not match)
        /// </summary>
        public Amount Amount { get; set; }
	}
}