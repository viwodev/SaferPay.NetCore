using SaferPay.Enums;

namespace SaferPay.Models.Core;

public class PayerProfile
{
    /// <summary>
    /// The payer's company
    /// </summary>
    public string Company { get; set; }

    /// <summary>
    /// Date and Time (ISO 8601) when user account was created<br/><br/>
    /// <i>Example: 2018-05-25T18:12:43Z</i>
    /// </summary>
    public string CreationDate { get; set; }

    /// <summary>
    /// The payer's date of birth (ISO 8601)<br/><br/>
    /// <i>Example: 1990-05-31</i>
    /// </summary>
    public string DateOfBirth { get; set; }

    /// <summary>
    /// The payer's email address
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// The payer's first name
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// The payer's gender<br/><br/>
    /// <i>Possible values: MALE, FEMALE, DIVERSE, COMPANY.</i>
    /// </summary>
    public GenderTypes Gender { get; set; }

    /// <summary>
    /// Does the payer have an account in the shop?
    /// </summary>
    public bool HasAccount { get; set; }

    /// <summary>
    /// Does the payer have a password?
    /// </summary>
    public bool HasPassword { get; set; }

    /// <summary>
    /// The payer's last login (ISO 8601)<br/><br/>
    /// <i>Example: 2018-05-25T18:12:43Z</i>
    /// </summary>
    public string LastLoginDate { get; set; }

    /// <summary>
    /// The payer's last name
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Was the password reset by the payer using the "forgot my password" feature in the current session?
    /// </summary>
    public bool PasswordForgotten { get; set; }

    /// <summary>
    /// Date and Time (ISO 8601) when the account password was changed last time<br/><br/>
    /// <i>Example: 2018-05-25T18:12:43Z</i>
    /// </summary>
    public string PasswordLastChangeDate { get; set; }

    /// <summary>
    /// The payer's phone numbers
    /// </summary>
    public Phone Phone { get; set; }

    /// <summary>
    /// The payer's secondary email address
    /// </summary>
    public string SecondaryEmail { get; set; }

}
