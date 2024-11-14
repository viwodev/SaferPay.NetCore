namespace SaferPay.Cards;


/// <summary>
/// It may be important to test certain flows and responses, during integration. For that, Saferpay offers the following test cards:
/// </summary>
public static class AmericanExpress
{

    static string[] Cards = new string[] { "9070003150000008" };

    /// <summary>
    /// <strong>9070 0031 5000 0008</strong><br/><br/>
    /// Frictionless Y. Card simulates a fully successfu<br/>
    /// <i>Frictionless Flow!</i><br/><br/>
    /// <strong>Liability shift: YES, Authenticated: true</strong>
    /// </summary>
    public static string Card_9070003150000008
    {
        get
        {
            return Cards[0];
        }
    }

}

/// <summary>
/// It may be important to test certain flows and responses, during integration. For that, Saferpay offers the following test cards:<br/><br/>
/// <i>V PAY is tested and processed as Visa.</i>
/// </summary>
public static class Visa
{
    static List<string> Cards = new List<string>() { "9010004150000009" };

    /// <summary>
    /// <strong>9010 0041 5000 0009</strong><br/>
    /// 3DS Failure, authorization will be attempted. This card fails the 3DS authentication. Interesting for testing the Condition parameter, to stop authorizations without LiabilityShift! Crd goes through a Challanged flow beforehand!<br/><br/>
    /// </summary>
    public static string _9010004150000009
    {
        get
        {
            return Visa.Cards[0];
        }
    }
}
