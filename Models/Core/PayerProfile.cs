using SaferPay.Enums;

namespace SaferPay.Models.Core;

/// <summary>
/// Represents a profile containing detailed information about a payer, including personal, account, and contact
/// details.
/// </summary>
/// <remarks>This class provides properties to store and retrieve information about a payer, such as their name,
/// email, date of birth,  account status, and contact details. It also includes metadata about the payer's account,
/// such as creation date, last login,  and password-related information. All date and time values are represented in
/// ISO 8601 format.<br/><br/>
/// Update Version : <see langword="1.46"/> <br/>
/// Updated At : <see langword="2025-05-16"/> <br/> 
/// </remarks>
public class PayerProfile
{
    /// <summary>
    /// The payer's company
    /// </summary>
    /// <value>
    /// <see langword="string"/>
    /// </value>
    public string Company { get; set; }


    /// <summary>
    /// Date and Time (ISO 8601) when user account was created<br/><br/>
    /// <i>Example: 2018-05-25T18:12:43Z</i>
    /// </summary>
    /// <value>
    /// <see langword="date"/>
    /// </value>
    public string CreationDate { get; set; }


    /// <summary>
    /// The payer's date of birth (ISO 8601)<br/><br/>
    /// <i>Example: 1990-05-31</i>
    /// </summary>
    /// <example>
    /// <code>1990-05-16</code>
    /// </example>
    public string DateOfBirth { get; set; }



    /// <summary>
    /// The payer's email address<br/><br/>
    /// <i>Example: payer@provider.com</i>
    /// </summary>
    public string Email { get; set; }


    /// <summary>
    /// The payer's first name
    /// </summary>
    public string FirstName { get; set; }


    /// <summary>
    /// The payer's gender<br/><br/>
    /// <i>Possible values: MALE, FEMALE, DIVERSE, COMPANY.</i><br/>
    /// <i>Example: COMPANY</i>
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
    /// The payer's secondary email address<br/><br/>
    /// <i>Example: payer_secondary@provider.com</i>
    /// </summary>
    public string SecondaryEmail { get; set; }


}
