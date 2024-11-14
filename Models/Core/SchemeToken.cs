using SaferPay.Enums;

namespace SaferPay.Models.Core;

/// <summary>
/// Surrogate values that replace the primary account number (PAN) according to the EMV Payment Tokenization Specification
/// </summary>
public class SchemeToken
{
    public SchemeToken() { }

    public SchemeToken(string number, int expMonth, int expYear, string verificationCode = "", string holderName = "")
    {
        Number = number.ToString().Replace(" ", "").Trim();
        ExpMonth = expMonth;
        ExpYear = expYear;

        if (ExpYear.ToString().Length == 2)
        {
            ExpYear = 2000 + ExpYear;
        }

    }

    /// <summary>
    /// <b>AuthValue <i>![Mandatory]</i></b><br/><br/>
    /// TAVV Cryptogram
    /// </summary>
    public string AuthValue { get; set; }

    /// <summary>
    /// Saferpay E-Commerce Indicator<br/><br/>
    /// <i>Example: 2023</i>
    /// </summary>
    public string Eci { get; set; }

    /// <summary>
    /// <b>ExpMonth <i>![Mandatory]</i></b><br/><br/>
    /// Month of expiration (eg 9 for September)<br/><br/>
    /// <i>Range: inclusive between 1 and 12<br/>
    /// Example: 9</i><br/>
    /// </summary>
    public int ExpMonth { get; set; }

    /// <summary>
    /// <b>ExpYear <i>![Mandatory]</i></b><br/><br/>
    /// Year of expiration<br/><br/>
    /// <i>Range: inclusive between 2000 and 9999<br/>
    /// Example: 2015</i><br/>
    /// </summary>
    public int ExpYear
    {
        get
        {
            return mExpYear;
        }

        set
        {
            if (value.ToString().Length == 2)
            {
                mExpYear = 2000 + value;
            }
            else
            {
                mExpYear = value;
            }
        }
    }
    private int mExpYear;

    /// <summary>
    /// <b>Number <i>![Mandatory]</i></b><br/><br/>
    /// Card number without separators<br/><br/>
    /// <i>Example: 1234123412341234</i><br></br>
    /// </summary>
    public string Number { get; set; }


    /// <summary>
    /// Type of the Scheme Token.<br/><br/>
    /// <i>Possible values: APPLEPAY, GOOGLEPAY, SAMSUNGPAY, CLICKTOPAY, OTHER, MDES, VTS.</i>
    /// </summary>
    public TokenTypes TokenType { get; set; }


}
