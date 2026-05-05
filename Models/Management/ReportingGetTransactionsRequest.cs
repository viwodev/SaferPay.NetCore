using Newtonsoft.Json;
using SaferPay.Enums;
using SaferPay.Models.Attributes;

namespace SaferPay.Models.Management;

public class ReportingGetTransactionsRequest : RestRequestBase
{

    /// <summary>
    /// State of the transactions to be retrieved. If left empty successful transactions are retrieved.
    /// </summary>
    [JsonProperty("TransactionState")]
    public TransactionState? TransactionState { get; set; }


    /// <summary>
    /// ID of the terminal the transactions should be retrieved for. If left empty, all terminals of the customer will be considered.
    /// </summary>
    [JsonProperty("TerminalId")]
    public int? TerminalId { get; set; }


    /// <summary>
    /// Only transactions happened later than this date will be returned.<br/><br/>
    /// Value can be provided in ISO 8601 format only using the date(yyyy-MM-dd) or as a date time(yyyy-MM-ddTHH:mm).
    /// </summary>
    [Mandatory]
    [JsonIgnore]
    public DateTime StartDate { get; set; } = DateTime.Now.AddDays(-30);

    [JsonProperty("StartDate")]
    public string StartDateQuery => StartDate.ToString("yyyy-MM-ddTHH:mm");

    /// <summary>
    /// Only transactions that occurred before this date will be returned.<br/><br/>
    /// EndDate must be less than today at 00:00 (midnight).<br/><br/>
    /// For example, to retrieve transactions up to and including yesterday, set EndDate to yesterday at 23:59.  Value can be provided in ISO 8601 format only using the date(yyyy-MM-dd) or as a date time(yyyy-MM-ddTHH:mm).
    /// </summary>
    [Mandatory]
    [JsonIgnore]
    public DateTime EndDate { get; set; } = DateTime.Now;


    [JsonProperty("EndDate")]
    public string EndDateQuery => EndDate.ToString("yyyy-MM-ddTHH:mm");


    /// <summary>
    /// Maximum number of transactions to be returned. If left empty, the default value of 1000 will be used. A maximum of 2000 transactions can be requested at once.<br/><br/>
    /// Please always make sure to check PageSize in the response as Saferpay reserves the right to shrink large page sizes to a reasonable value.
    /// </summary>
    [JsonProperty("PageSize")]
    public int? PageSize { get; set; }


    /// <summary>
    /// Number of the page to be returned, starting from 1. Values smaller than 1 will be automatically set to 1. Previous pages will be skipped. If left empty, the first page will be returned.
    /// </summary>
    [JsonProperty("PageNumber")]
    public int? PageNumber { get; set; }
}
