using SaferPay.Interfaces;
using SaferPay.Models.Core;
using SaferPay.Models.Management;

namespace SaferPay.Channels;

public class ManagementApi : IManagementApi
{
    private readonly ISaferPayClient _client;

    public ManagementApi(SaferPaySettings settings) => _client = new SaferPayClient(settings);

    public ManagementApi(ISaferPayClient client) => _client = client ?? throw new ArgumentNullException(nameof(client));

    public ManagementApi(string customerId, string terminalId, string userName, string passWord, bool sandBox = false)
        => _client = new SaferPayClient(new SaferPaySettings(customerId, terminalId, userName, passWord, sandBox));

    public ManagementBaseResponse LicensingCustomerLicense() =>
        LicensingCustomerLicenseAsync().GetAwaiter().GetResult();

    public Task<ManagementBaseResponse> LicensingCustomerLicenseAsync()
    {
        var endpoint = $"rest/customers/{_client.CustomerId}/license";
        return _client.GetAsync<ManagementBaseResponse>(endpoint);
    }

    public RestResponseBase LicensingCustomerLicenseConfiguration() =>
        LicensingCustomerLicenseConfigurationAsync().GetAwaiter().GetResult();

    public Task<RestResponseBase> LicensingCustomerLicenseConfigurationAsync()
    {
        var endpoint = $"rest/customers/{_client.CustomerId}/license-configuration";
        return _client.GetAsync<RestResponseBase>(endpoint);
    }

    public ManagementConfigurations PaymentPageConfigGetConfigurations() =>
        PaymentPageConfigGetConfigurationsAsync().GetAwaiter().GetResult();

    public Task<ManagementConfigurations> PaymentPageConfigGetConfigurationsAsync()
    {
        var endpoint = $"rest/customers/{_client.CustomerId}/payment-page/configurations";
        return _client.GetAsync<ManagementConfigurations>(endpoint);
    }

    public CreateAccessTokenResponse SaferpayFieldsAccessTokenCreateAccessToken(CreateAccessTokenRequest request) =>
        SaferpayFieldsAccessTokenCreateAccessTokenAsync(request).GetAwaiter().GetResult();

    public Task<CreateAccessTokenResponse> SaferpayFieldsAccessTokenCreateAccessTokenAsync(CreateAccessTokenRequest request)
    {
        var endpoint = $"rest/customers/{_client.CustomerId}/terminals/{_client.TerminalId}/fields-access-tokens";
        return _client.PostAsync<CreateAccessTokenResponse, CreateAccessTokenRequest>(endpoint, request);
    }

    public RestResponseBase SaferpayFieldsAccessTokenDeleteAccessToken(string accessToken) =>
        SaferpayFieldsAccessTokenDeleteAccessTokenAsync(accessToken).GetAwaiter().GetResult();

    public Task<RestResponseBase> SaferpayFieldsAccessTokenDeleteAccessTokenAsync(string accessToken)
    {
        var endpoint = $"rest/customers/{_client.CustomerId}/terminals/{_client.TerminalId}/fields-access-tokens/{accessToken}";
        return _client.DeleteAsync<RestResponseBase>(endpoint);
    }

    public CreateSingleUsePaymentLinkResponse SecurePayGateCreateSingleUsePaymentLink(CreateSingleUsePaymentLinkRequest request) =>
        SecurePayGateCreateSingleUsePaymentLinkAsync(request).GetAwaiter().GetResult();

    public Task<CreateSingleUsePaymentLinkResponse> SecurePayGateCreateSingleUsePaymentLinkAsync(CreateSingleUsePaymentLinkRequest request)
    {
        var endpoint = $"rest/customers/{_client.CustomerId}/terminals/{_client.TerminalId}/spg-offers";
        return _client.PostAsync<CreateSingleUsePaymentLinkResponse, CreateSingleUsePaymentLinkRequest>(endpoint, request);
    }

    public SingleUsePaymentLinkResponse SecurePayGateSingleUsePaymentLink(string offerId) =>
        SecurePayGateSingleUsePaymentLinkAsync(offerId).GetAwaiter().GetResult();

    public Task<SingleUsePaymentLinkResponse> SecurePayGateSingleUsePaymentLinkAsync(string offerId)
    {
        var endpoint = $"rest/customers/{_client.CustomerId}/terminals/{_client.TerminalId}/spg-offers/{offerId}";
        return _client.GetAsync<SingleUsePaymentLinkResponse>(endpoint);
    }

    public TerminalResponse TerminalGetTerminal() =>
        TerminalGetTerminalAsync().GetAwaiter().GetResult();

    public Task<TerminalResponse> TerminalGetTerminalAsync()
    {
        var endpoint = $"rest/customers/{_client.CustomerId}/terminals/{_client.TerminalId}";
        return _client.GetAsync<TerminalResponse>(endpoint);
    }

    public TerminalsResponse TerminalsGetTerminals() =>
        TerminalsGetTerminalsAsync().GetAwaiter().GetResult();

    public Task<TerminalsResponse> TerminalsGetTerminalsAsync()
    {
        var endpoint = $"rest/customers/{_client.CustomerId}/terminals";
        return _client.GetAsync<TerminalsResponse>(endpoint);
    }

    public ReportingGetTransactionsResponse TransactionReportingGetTransactions(ReportingGetTransactionsRequest request) =>
        TransactionReportingGetTransactionsAsync(request).GetAwaiter().GetResult();

    public Task<ReportingGetTransactionsResponse> TransactionReportingGetTransactionsAsync(ReportingGetTransactionsRequest request)
    {
        var endpoint = $"rest/customers/{_client.CustomerId}/transactions";
        return _client.GetAsync<ReportingGetTransactionsResponse, ReportingGetTransactionsRequest>(endpoint, request);
    }
}
