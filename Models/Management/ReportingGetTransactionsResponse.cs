namespace SaferPay.Models.Management;

public class ReportingGetTransactionsResponse : RestResponseBase
{


    /// <summary>
    /// Size of the returned page. This can vary from the requested page size if a page size above the maximum page size was requested.<br/><br/>
    /// Please always check when processing the result.
    /// </summary>
    public int PageNumber { get; set; }

    /// <summary>
    /// Number of the returned page, starting from 0
    /// </summary>
    public int PageSize { get; set; }


    /// <summary>
    /// Total number of transactions matching the request, regardless of the pagination
    /// </summary>
    public int TotalTransactions { get; set; }

    /// <summary>
    /// List of transactions on the requested page
    /// </summary>
    public List<Transaction> Transactions { get; set; }

}
