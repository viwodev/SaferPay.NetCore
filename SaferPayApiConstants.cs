using SaferPay.Models;

namespace SaferPay
{

    public static class SaferPayApiConstants
    {
        public const string Version = "1.33";
    }

    public static class Settings
    {
        /// <summary>
        /// Sets or Gets Global Default Settings
        /// </summary>
        public static SaferPaySettings Default { get; set; } = new SaferPaySettings();

        /// <summary>
        /// Returns Client Instance from Global Settings
        /// </summary>
        /// <returns></returns>
        public static ISaferPayClient Client() => new SaferPayClient(Default.CustomerId, Default.TerminalId, Default.Username, Default.Password, Default.SandBox);

    }

}