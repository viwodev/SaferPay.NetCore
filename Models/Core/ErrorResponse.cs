using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SaferPay.Enums;

namespace SaferPay.Models.Core
{
    public class ErrorResponse : ResponseBase
    {
        /// <summary>
        /// Contains additional risk related information for the transaction that is blocked by risk.
        /// </summary>
        public Risk Risk { get; set; }

        /// <summary>
        /// What can be done to resolve the error?
        /// </summary>
        public BehaviorTypes Behavior { get; set; }

        /// <summary>
        /// Name / id of the error.
        /// </summary>
        public ErrorNames ErrorName { get; set; }

        /// <summary>
        /// Description of the error.
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Id of the failed transaction, if available
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// More details, if available. Contents may change at any time, so don’t parse it.
        /// </summary>
        public string[] ErrorDetail { get; set; }

        /// <summary>
        /// Name of acquirer (if declined by acquirer) or processor
        /// </summary>
        public string ProcessorName { get; set; }

        /// <summary>
        /// Result code returned by acquirer or processor
        /// </summary>
        public string ProcessorResult { get; set; }

        /// <summary>
        /// Message returned by acquirer or processor
        /// </summary>
        public string ProcessorMessage { get; set; }

        /// <summary>
        /// A text message provided by the card issuer detailing the reason for a declined authorization. It is safe to display it to the payer.
        /// </summary>
        public string PayerMessage { get; set; }

        /// <summary>
        /// OrderId of the failed transaction. This is only returned in the PaymentPage Assert Response and the Transaction Authorize Response.
        /// </summary>
        public string OrderId { get; set; }


        [JsonExtensionData]
        public IDictionary<string, JToken> Unknown { get; set; }

        public override string ToString()
        {
            return ErrorMessage ?? string.Empty;
        }

    }
}