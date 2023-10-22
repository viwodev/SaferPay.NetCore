using SaferPay.Enums;
using SaferPay.Models.Core;

namespace SaferPay.Models.Transaction
{
    public class CaptureResponse : ResponseBase
    {
        /// <summary>
        /// CaptureId of the created capture. Must be stored for later reference (eg refund).<br/><br/>
        /// <i>Id[1..64]<br/>
        /// Example: ECthWpbv1SI6SAIdU2p6AIC1bppA_c</i>
        /// </summary>
        public string CaptureId { get; set; }

        /// <summary>
        /// Current status of the capture. (PENDING is only used for paydirekt at the moment)<br/><br/>
        /// <i>Possible values: PENDING, CAPTURED.</i><br/>
        /// <strong>Mandatory</strong>
        /// </summary>
        public TransactionStatus Status { get; set; }

        /// <summary>
        /// Date and time of capture. Not set if the capture state is pending.<br/><br/>
        /// <i>Example: 2014-04-25T08:33:44.159+01:00</i><br/>
        /// <strong>Mandatory</strong>
        /// </summary>
		public DateTime Date { get; set; }

        /// <summary>
        /// Optional infos for invoice based payments.
        /// </summary>
        public Invoice Invoice { get; set; }

        public override string ToString()
        {
            return Status.ToString();
        }
    }

}