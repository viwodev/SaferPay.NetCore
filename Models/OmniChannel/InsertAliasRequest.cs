using SaferPay.Models.Core;

namespace SaferPay.Models.OmniChannel
{
    /// <summary>
    /// Insert Alias Request
    /// </summary>
    public class InsertAliasRequest : RequestBase
    {
        /// <summary>
        /// Registration parameters
        /// </summary>
        public RegisterAlias RegisterAlias { get; set; }

        /// <summary>
        /// SIX Transaction Reference<br/><br/>
        /// <i>Example: 1:100002:199970683910</i>
        /// </summary>
        public string SixTransactionReference { get; set; }
    }
}
