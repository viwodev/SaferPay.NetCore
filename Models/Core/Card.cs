using SaferPay.Enums;

namespace SaferPay.Models.Core;

public class Card
{

    public Card() { }

    public Card(string number, int expMonth, int expYear, string verificationCode = "", string holderName = "")
    {
        Number = number.ToString().Replace(" ", "").Trim();
        ExpMonth = expMonth;
        ExpYear = expYear;

        if (ExpYear.ToString().Length == 2)
        {
            ExpYear = 2000 + ExpYear;
        }

        VerificationCode = verificationCode;
        HolderName = holderName;
    }

    public Card(string number, int expMonth, int expYear, int verificationCode, string holderName = "")
    {
        Number = number.ToString().Replace(" ", "").Trim();
        ExpMonth = expMonth;
        ExpYear = expYear;

        if (ExpYear.ToString().Length == 2)
        {
            ExpYear = 2000 + ExpYear;
        }

        VerificationCode = verificationCode.ToString();
        HolderName = holderName;
    }

    /// <summary>
    /// <b>Number <i>![Mandatory]</i></b><br/><br/>
    /// Card number without separators<br/><br/>
    /// <i>Example: 1234123412341234</i><br></br>
    /// </summary>
    public string Number { get; set; }

    /// <summary>
    /// Masked Card Number
    /// </summary>
    public string MaskedNumber { get; set; }

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
    /// <b>ExpMonth <i>![Mandatory]</i></b>
    /// Month of expiration (eg 9 for September)<br/><br/>
    /// <i>Range: inclusive between 1 and 12<br/>
    /// Example: 9</i><br/>
    /// <strong>Mandatory</strong>
    /// </summary>
    public int ExpMonth { get; set; }

    /// <summary>
    /// Name of the card holder<br/><br/>
    /// <i>Utf8[1..50]<br/>
    /// Example: John Doe</i>
    /// </summary>
    public string HolderName { get; set; }

    /// <summary>
    /// Verification code (CVV, CVC) if applicable<br/><br/>
    /// <i>Numeric[3..4]<br/>
    /// Example: 123</i>
    /// </summary>
    public string VerificationCode { get; set; }

    /// <summary>
    /// The Segment of card holder. Only returned for Alias/AssertInsert, Alias/InsertDirect and Alias/Update calls if available.<br/><br/>
    /// <i>
    /// Possible values: UNSPECIFIED, CONSUMER, CORPORATE, CORPORATE_AND_CONSUMER.
    /// </i>
    /// </summary>
    public HolderSegmentTypes HolderSegment { get; set; }

    /// <summary>
    /// ISO 2-letter country code of the card origin (if available)
    /// </summary>
    public string CountryCode { get; set; }

    /// <summary>
    /// The HashValue, if the hash generation is configured for the customer.
    /// </summary>
    public string HashValue { get; set; }

    /// <summary>
    /// Contains information about the tokenPAN if the transaction, or the referenced transaction, was conducted with a scheme token PAN.
    /// </summary>
    public TokenPan TokenPan { get; set; }
}
