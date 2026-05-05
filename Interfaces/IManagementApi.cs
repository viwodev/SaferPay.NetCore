using SaferPay.Models.Core;
using SaferPay.Models.Management;

namespace SaferPay.Interfaces;

/// <summary>
/// https://saferpay.github.io/jsonapi/index.html#ChapterManagementApi
/// </summary>
public interface IManagementApi
{
    /// <summary>
    /// This method is used to retrieve the current license configuration for a customer
    /// </summary>
    /// <returns></returns>
    public ManagementBaseResponse LicensingCustomerLicense();


    /// <summary>
    /// This method is used to retrieve the current license configuration for a customer
    /// </summary>
    /// <returns></returns>
    [Obsolete("Since Version 1.35. Please use instead: /rest/customers/{customerId}/license")]
    public RestResponseBase LicensingCustomerLicenseConfiguration();


    /// <summary>
    /// This method is used to retrieve all terminals
    /// </summary>
    /// <returns></returns>
    public ManagementConfigurations PaymentPageConfigGetConfigurations();


    /// <summary>
    /// Create a Saferpay Fields Access Token that can be used to integrate Saferpay Fields into web pages and is restricted to the given customerId, terminalId and URL(s).
    /// </summary>
    /// <returns></returns>
    public CreateAccessTokenResponse SaferpayFieldsAccessTokenCreateAccessToken(CreateAccessTokenRequest request);


    /// <summary>
    /// This method may be used to delete a previously created Saferpay Fields Access Token.
    /// </summary>
    /// <returns></returns>
    public RestResponseBase SaferpayFieldsAccessTokenDeleteAccessToken(string accessToken);


    /// <summary>
    /// This function may be used to create a single use payment link
    /// </summary>
    /// <returns></returns>
    public CreateSingleUsePaymentLinkResponse SecurePayGateCreateSingleUsePaymentLink(CreateSingleUsePaymentLinkRequest request);


    /// <summary>
    /// This function may be used to fetch the status of a previously created single use payment link
    /// </summary>
    /// <returns></returns>
    public SingleUsePaymentLinkResponse SecurePayGateSingleUsePaymentLink(string offerId);


    /// <summary>
    /// This method is used to retrieve details of one terminal
    /// </summary>
    /// <returns></returns>
    public TerminalResponse TerminalGetTerminal();

    /// <summary>
    /// This method is used to retrieve all terminals
    /// </summary>
    /// <returns></returns>
    public TerminalsResponse TerminalsGetTerminals();


    /// <summary>
    /// This method is used to retrieve a list of transactions based on the provided criteria.
    /// </summary>
    /// <returns></returns>
    public ReportingGetTransactionsResponse TransactionReportingGetTransactions(ReportingGetTransactionsRequest request);

    #region AsyncCalls
    /// <summary>
    /// This method is used to retrieve the current license configuration for a customer
    /// </summary>
    /// <returns></returns>
    public Task<ManagementBaseResponse> LicensingCustomerLicenseAsync();


    /// <summary>
    /// This method is used to retrieve the current license configuration for a customer
    /// </summary>
    /// <returns></returns>
    [Obsolete("Since Version 1.35. Please use instead: /rest/customers/{customerId}/license")]
    public Task<RestResponseBase> LicensingCustomerLicenseConfigurationAsync();


    /// <summary>
    /// This method is used to retrieve all terminals
    /// </summary>
    /// <returns></returns>
    public Task<ManagementConfigurations> PaymentPageConfigGetConfigurationsAsync();


    /// <summary>
    /// Create a Saferpay Fields Access Token that can be used to integrate Saferpay Fields into web pages and is restricted to the given customerId, terminalId and URL(s).
    /// </summary>
    /// <returns></returns>
    public Task<CreateAccessTokenResponse> SaferpayFieldsAccessTokenCreateAccessTokenAsync(CreateAccessTokenRequest request);


    /// <summary>
    /// This method may be used to delete a previously created Saferpay Fields Access Token.
    /// </summary>
    /// <returns></returns>
    public Task<RestResponseBase> SaferpayFieldsAccessTokenDeleteAccessTokenAsync(string accessToken);


    /// <summary>
    /// This function may be used to create a single use payment link
    /// </summary>
    /// <returns></returns>
    public Task<CreateSingleUsePaymentLinkResponse> SecurePayGateCreateSingleUsePaymentLinkAsync(CreateSingleUsePaymentLinkRequest request);


    /// <summary>
    /// This function may be used to fetch the status of a previously created single use payment link
    /// </summary>
    /// <returns></returns>
    public Task<SingleUsePaymentLinkResponse> SecurePayGateSingleUsePaymentLinkAsync(string offerId);


    /// <summary>
    /// This method is used to retrieve details of one terminal
    /// </summary>
    /// <returns></returns>
    public Task<TerminalResponse> TerminalGetTerminalAsync();

    /// <summary>
    /// This method is used to retrieve all terminals
    /// </summary>
    /// <returns></returns>
    public Task<TerminalsResponse> TerminalsGetTerminalsAsync();


    /// <summary>
    /// This method is used to retrieve a list of transactions based on the provided criteria.
    /// </summary>
    /// <returns></returns>
    public Task<ReportingGetTransactionsResponse> TransactionReportingGetTransactionsAsync(ReportingGetTransactionsRequest request);
    #endregion


}
