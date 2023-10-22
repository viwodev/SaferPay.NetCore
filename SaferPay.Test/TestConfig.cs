namespace SaferPay.Test
{
    public static class TestConfig
    {
        public static string ApiUserName { get; set; } = "API_268079_69541955";

        public static string ApiPassword { get; set; } = "!S4f3Rp4%y?0_T35T";

        public static string ApiKey { get; set; } = "QVBJXzI2ODA3OV82OTU0MTk1NTohUzRmM1JwNCV5PzBfVDM1VA==";

        public static string TerminalId { get; set; } = "17757286";

        public static string CustomerId { get; set; } = "268079";

        public static bool SandBox { get; set; } = true;

        public static string WebPage { get; set; } = "http://localhost:5000/";

        public static List<TestCard> Cards { get; set; } = new List<TestCard>() { new TestCard("9010003150000001", "Viwo Dev", "1230", "123") };

        public static string Currency = "TRY";

    }

}
