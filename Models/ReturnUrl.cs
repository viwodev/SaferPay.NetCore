namespace SaferPay.Models
{
    public class ReturnUrl
    {
        public ReturnUrl()
        {
        }

        public ReturnUrl(string url)
        {
            this.Url = new Uri(url);
        }

        /// <summary>
        /// Return url for successful, failed or aborted transaction<br/><br/>
        /// <strong>Mandatory</strong>
        /// </summary>
        public Uri Url { get; set; }

        public override string ToString()
        {
            return Url.ToString();
        }

        public static implicit operator ReturnUrl(string url)
        {
            return new ReturnUrl(url);
        }

    }
}
