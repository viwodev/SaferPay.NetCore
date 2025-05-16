using SaferPay.Enums;

namespace SaferPay.Models.Core;


/// <summary>
/// Represents a payer in a transaction, including identifying information, device details, and address data.
/// </summary>
/// <remarks>
/// This class provides detailed information about the payer, such as their unique identifier, IP
/// address,  browser and device capabilities, and billing and delivery addresses. It is designed to capture relevant 
/// data for payment processing and fraud detection.<br/><br/>
/// Update Version : <see langword="1.46"/> <br/>
/// Updated At : <see langword="2025-05-16"/> <br/> 
/// </remarks>
public class Payer
{

    /// <summary>
    /// Browser accept header
    /// </summary>
    /// <remarks>
    /// <i>Example: text/html, application/xhtml, application/xml</i>
    /// </remarks>
    public string AcceptHeader { get; set; }


    /// <summary>
    /// Information on the payers billing address
    /// </summary>
    public PayerAddress BillingAddress { get; set; }


    /// <summary>
    /// Color depth
    /// </summary>
    /// <remarks>
    /// <i>Possible values: 1bit, 4bits, 8bits, 15bits, 16bits, 24bits, 32bits, 48bits.</i><br/>
    /// <i>Example: 32bits</i>
    /// </remarks>
    public string ColorDepth { get; set; }


    /// <summary>
    /// Information on the payers delivery address
    /// </summary>
    public PayerAddress DeliveryAddress { get; set; }


    /// <summary>
    /// Payer identifier defined by the merchant / shop. The ID can be numeric, alphabetical and contain any of the following special characters: .:!#$%&'*+-/=?^_`{|}~@.<br/>
    /// For GDPR reasons, we don't recommend using an id which contains personal data (eg. no name).
    /// </summary>
    public string Id { get; set; }


    /// <summary>
    /// IPv4 address of the card holder / payer if available. Dotted quad notation.
    /// </summary>
    /// <remarks>
    /// <i>
    /// Example: 111.111.111.111
    /// </i>
    /// </remarks>
    public string IpAddress { get; set; }


    /// <summary>
    /// IPv6 address of the card holder / payer if available.
    /// </summary>
    /// <remarks>
    /// <i>
    /// Example: 2001:0db8:0000:08d3:0000:8a2e:0070:7344</i>
    /// </remarks>
    public string Ip6Address { get; set; }


    /// <summary>
    /// Is Java enabled
    /// </summary>
    public bool JavaEnabled { get; set; }


    /// <summary>
    /// Is JavaScript enabled
    /// </summary>
    public bool JavaScriptEnabled { get; set; }


    /// <summary>
    /// Language to force Saferpay to display something to the payer in a certain language. Per default, Saferpay will determine the language using the payers browser agent.<br/>
    /// Format: ISO 639-1 (two-letter language code), optionally followed by a hyphen and ISO 3166-1 alpha-2 (two-letter country code).<br/>
    /// The supported language codes are listed below.This list may be extended in the future as more languages become available.<br/>
    /// We recommend to only use supported language and country codes.If the submitted value has a valid format, but the language is unsupported, then the default language is used.<br/>
    /// For supported languages, using different country codes than those explicitly listed here may or may not work as expected.<br/>
    /// </summary>
    /// <remarks>
    /// Example: de
    /// </remarks>
    /// [JsonConverter(typeof(LanguageEnumConverter))]
    public Languages LanguageCode { get; set; }


    /// <summary>
    /// Screen height
    /// </summary>
    /// <remarks>
    /// <i>
    /// Example: 1080
    /// </i>
    /// </remarks>
    public int ScreenHeight { get; set; }


    /// <summary>
    /// Screen width
    /// </summary>
    /// <remarks>
    /// <i>
    /// Example: 1920
    /// </i>
    /// </remarks>
    public int ScreenWidth { get; set; }


    /// <summary>
    /// Time zone offset in minutes
    /// </summary>
    /// <remarks>
    /// <i>
    /// Example: 720
    /// </i>
    /// </remarks>
    public int TimeZoneOffsetMinutes { get; set; }


    /// <summary>
    /// User agent
    /// </summary>
    /// <remarks>
    /// <i>
    /// Example: Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:47.0) Gecko/20100101 Firefox/47.0
    /// </i>
    /// </remarks>
    public string UserAgent { get; set; }


    /// <summary>
    /// The location the IpAddress, if available. This might be a valid country code or a special value for 'non-country' locations (anonymous proxy, satellite phone, ...).<br/><br/>
    /// <i>Example: NZ</i>
    /// </summary>
    public string IpLocation { get; set; }

}