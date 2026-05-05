using SaferPay.Interfaces;
using SaferPay.Models.Core;
using SaferPay.Models.Management;

namespace SaferPay.Channels;

public class ManagementApi : IManagementApi
{
    private readonly ISaferPayClient _client;

    public ManagementApi(SaferPaySettings settings) => _client = new SaferPayClient(settings);

    public ManagementApi(ISaferPayClient client) => _client = client;

    public ManagementApi(string customerId, string terminalId, string userName, string passWord, bool sandBox = false) => _client = new SaferPayClient(new SaferPaySettings(customerId, terminalId, userName, passWord, sandBox));

    public ManagementBaseResponse LicensingCustomerLicense()
    {
        if (_client == null) return default;
        var data = LicensingCustomerLicenseAsync().GetAwaiter().GetResult();
        return data;
    }

    public async Task<ManagementBaseResponse> LicensingCustomerLicenseAsync()
    {
        if (_client == null) return default;
        var endpoint = $"rest/customers/{_client.CustomerId}/license";

        var response = await _client.GetAsync<ManagementBaseResponse>(endpoint);
        return response;
    }

    public RestResponseBase LicensingCustomerLicenseConfiguration()
    {
        if (_client == null) return default;
        var data = LicensingCustomerLicenseConfigurationAsync().GetAwaiter().GetResult();
        return data;
    }

    public async Task<RestResponseBase> LicensingCustomerLicenseConfigurationAsync()
    {
        if (_client == null) return default;
        var endpoint = $"rest/customers/{_client.CustomerId}/license-configuration";

        var response = await _client.GetAsync<RestResponseBase>(endpoint);
        return response;
    }

    public ManagementConfigurations PaymentPageConfigGetConfigurations()
    {
        if (_client == null) return default;
        var data = PaymentPageConfigGetConfigurationsAsync().GetAwaiter().GetResult();
        return data;
    }

    public async Task<ManagementConfigurations> PaymentPageConfigGetConfigurationsAsync()
    {
        if (_client == null) return default;
        var endpoint = $"rest/customers/{_client.CustomerId}/payment-page/configurations";

        var response = await _client.GetAsync<ManagementConfigurations>(endpoint);
        return response;
    }

    public CreateAccessTokenResponse SaferpayFieldsAccessTokenCreateAccessToken(CreateAccessTokenRequest request)
    {
        if (_client == null) return default;
        var data = SaferpayFieldsAccessTokenCreateAccessTokenAsync(request).GetAwaiter().GetResult();
        return data;
    }

    public async Task<CreateAccessTokenResponse> SaferpayFieldsAccessTokenCreateAccessTokenAsync(CreateAccessTokenRequest request)
    {
        if (_client == null) return default;
        var endpoint = $"rest/customers/{_client.CustomerId}/terminals/{_client.TerminalId}/fields-access-tokens";

        var response = await _client.PostAsync<CreateAccessTokenResponse, CreateAccessTokenRequest>(endpoint, request);
        return response;
    }

    public RestResponseBase SaferpayFieldsAccessTokenDeleteAccessToken(string accessToken)
    {
        if (_client == null) return default;
        var data = SaferpayFieldsAccessTokenDeleteAccessTokenAsync(accessToken).GetAwaiter().GetResult();
        return data;
    }

    public async Task<RestResponseBase> SaferpayFieldsAccessTokenDeleteAccessTokenAsync(string accessToken)
    {
        if (_client == null) return default;
        var endpoint = $"rest/customers/{_client.CustomerId}/terminals/{_client.TerminalId}/fields-access-tokens/{accessToken}";

        var response = await _client.DeleteAsync<RestResponseBase>(endpoint);
        return response;
    }

    public CreateSingleUsePaymentLinkResponse SecurePayGateCreateSingleUsePaymentLink(CreateSingleUsePaymentLinkRequest request)
    {
        if (_client == null) return default;
        var data = SecurePayGateCreateSingleUsePaymentLinkAsync(request).GetAwaiter().GetResult();
        return data;
    }

    public async Task<CreateSingleUsePaymentLinkResponse> SecurePayGateCreateSingleUsePaymentLinkAsync(CreateSingleUsePaymentLinkRequest request)
    {
        if (_client == null) return default;
        var endpoint = $"rest/customers/{_client.CustomerId}/terminals/{_client.TerminalId}/spg-offers";

        var response = await _client.PostAsync<CreateSingleUsePaymentLinkResponse, CreateSingleUsePaymentLinkRequest>(endpoint, request);
        return response;
    }

    public SingleUsePaymentLinkResponse SecurePayGateSingleUsePaymentLink(string offerId)
    {
        if (_client == null) return default;
        var data = SecurePayGateSingleUsePaymentLinkAsync(offerId).GetAwaiter().GetResult();
        return data;
    }

    public async Task<SingleUsePaymentLinkResponse> SecurePayGateSingleUsePaymentLinkAsync(string offerId)
    {
        if (_client == null) return default;
        var endpoint = $"rest/customers/{_client.CustomerId}/terminals/{_client.TerminalId}/spg-offers/{offerId}";
        var response = await _client.GetAsync<SingleUsePaymentLinkResponse>(endpoint);
        return response;
    }

    public TerminalResponse TerminalGetTerminal()
    {
        if (_client == null) return default;
        var data = TerminalGetTerminalAsync().GetAwaiter().GetResult();
        return data;
    }

    public async Task<TerminalResponse> TerminalGetTerminalAsync()
    {
        if (_client == null) return default;
        var endpoint = $"rest/customers/{_client.CustomerId}/terminals/{_client.TerminalId}";
        var response = await _client.GetAsync<TerminalResponse>(endpoint);
        return response;
    }

    public TerminalsResponse TerminalsGetTerminals()
    {
        if (_client == null) return default;
        var data = TerminalsGetTerminalsAsync().GetAwaiter().GetResult();
        return data;
    }

    public async Task<TerminalsResponse> TerminalsGetTerminalsAsync()
    {
        if (_client == null) return default;
        var endpoint = $"rest/customers/{_client.CustomerId}/terminals";
        var response = await _client.GetAsync<TerminalsResponse>(endpoint);
        return response;
    }

    public ReportingGetTransactionsResponse TransactionReportingGetTransactions(ReportingGetTransactionsRequest request)
    {
        if (_client == null) return default;
        var data = TransactionReportingGetTransactionsAsync(request).GetAwaiter().GetResult();
        return data;
    }

    public async Task<ReportingGetTransactionsResponse> TransactionReportingGetTransactionsAsync(ReportingGetTransactionsRequest request)
    {
        if (_client == null) return default;
        var endpoint = $"rest/customers/{_client.CustomerId}/transactions";
        var response = await _client.GetAsync<ReportingGetTransactionsResponse, ReportingGetTransactionsRequest>(endpoint, request);
        return response;
    }
}
