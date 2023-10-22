using SaferPay.Models.Core;

namespace SaferPay.Models.SecureData
{
    public class AliasDeleteRequest : RequestBase
    {
        /// <summary>
        /// The Alias you want to delete. This value is case-insensitive.
        /// </summary>
        public string AliasId { get; set; }
    }
}
