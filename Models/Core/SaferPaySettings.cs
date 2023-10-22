using Newtonsoft.Json;

namespace SaferPay.Models.Core
{
    public class SaferPaySettings
    {

        public SaferPaySettings()
        {
        }

        public SaferPaySettings(string customerId, string terminalId, string userName, string passWord, bool sandBox = false)
        {
            CustomerId = customerId;
            TerminalId = terminalId;
            Username = userName;
            Password = passWord;
            SandBox = sandBox;
        }

        [JsonIgnore]
        public Uri BaseUri
        {
            get
            {
                return SandBox ? new Uri("https://test.saferpay.com/api/") : new Uri("https://www.saferpay.com/api/");
            }
        }

        [JsonProperty("sandbox")]
        public bool SandBox { get; set; } = false;

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("customerId")]
        public string CustomerId { get; set; }

        [JsonProperty("terminalId")]
        public string TerminalId { get; set; }

        [JsonProperty("throwException")]
        public bool ThrowExceptionOnFail { get; set; } = false;
    }
}