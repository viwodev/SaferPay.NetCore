using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SaferPay.Models
{
    public class ErrorResponse : ResponseBase
    {
        public string Behavior { get; set; }

        /// <summary>
        /// Name / id of the error.
        /// </summary>
        public string ErrorName { get; set; }

        /// <summary>
        /// Description of the error.
        /// </summary>
        public string ErrorMessage { get; set; }
        public string TransactionId { get; set; }
        public string ProcessorName { get; set; }
        public string ProcessorResult { get; set; }
        public string ProcessorMessage { get; set; }
        public string[] ErrorDetail { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> Unknown { get; set; }

        public override string ToString()
        {
            return this.ErrorMessage ?? string.Empty;
        }

    }
}