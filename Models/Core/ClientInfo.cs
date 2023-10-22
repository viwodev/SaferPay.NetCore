namespace SaferPay.Models.Core
{
    public class ClientInfo
    {
        /// <summary>
        /// Name and version of the shop software
        /// </summary>
        public string ShopInfo { get; set; }

        /// <summary>
        /// Information on the operating system
        /// </summary>
        public string OsInfo { get; set; }
    }
}