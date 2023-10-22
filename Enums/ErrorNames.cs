using Newtonsoft.Json.Converters;
using System.ComponentModel;

namespace SaferPay.Enums
{
    /// <summary>
    /// Error Names
    /// </summary>
    [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
    public enum ErrorNames
    {
        /// <summary>
        /// The requested action is not supported in the given context or the action can't be executed with the request data.
        /// </summary>
        [Description("Action Not Supported")]
        ACTION_NOT_SUPPORTED,

        /// <summary>
        /// The alias is not known or already used (in case of registration). Solution: Use another alias for registration.
        /// </summary>
        [Description("Alias Invalid")]
        ALIAS_INVALID,

        /// <summary>
        /// The amount does not adhere to the restrictions for this action. E.g. it might be exceeding the allowed capture amount.
        /// </summary>
        [Description("Invalid Amount")]
        AMOUNT_INVALID,

        /// <summary>
        /// Wrong password, wrong client certificate, invalid token, wrong HMAC. Solution: Use proper credentials, fix HMAC calculation, use a valid token.
        /// </summary>
        [Description("Authentication Failed")]
        AUTHENTICATION_FAILED,

        /// <summary>
        /// Action blocked by risk management. Solution: Unblock in Saferpay Risk Management (Backoffice).
        /// </summary>
        [Description("Blocked by Risk Management")]
        BLOCKED_BY_RISK_MANAGEMENT,

        /// <summary>
        /// Invalid card number or cvc (this is only returned for the SIX-internal card check feature for Alias/InsertDirect). Solution: Let the card holder correct the entered data.
        /// </summary>
        [Description("Card Check Failed")]
        CARD_CHECK_FAILED,

        /// <summary>
        /// Wrong cvc entered. Solution: Retry with the correct cvc.
        /// </summary>
        [Description("Invalid Card CVC")]
        CARD_CVC_INVALID,

        /// <summary>
        /// Cvc not entered but required. Solution: Retry with cvc entered.
        /// </summary>
        [Description("Card CVC Required")]
        CARD_CVC_REQUIRED,

        /// <summary>
        /// The communication to the processor failed. Solution: Try again or use another means of payment.
        /// </summary>
        [Description("Communication Failed")]
        COMMUNICATION_FAILED,

        /// <summary>
        /// Saferpay did not receive a response from the external system in time. It’s possible that an authorization was created, but Saferpay is not able to know this. Solution: Check with the acquirer if there is an authorization which needs to be canceled.
        /// </summary>
        [Description("Communication Timeout")]
        COMMUNICATION_TIMEOUT,

        /// <summary>
        /// The condition which was defined in the request could not be satisfied.
        /// </summary>
        [Description("Condition Not Satisfied")]
        CONDITION_NOT_SATISFIED,

        /// <summary>
        /// Currency does not match referenced transaction currency.
        /// </summary>
        [Description("Invalid Currency")]
        CURRENCY_INVALID,

        /// <summary>
        /// Transaction declined by an unknown reason.
        /// </summary>
        [Description("General Declined")]
        GENERAL_DECLINED,

        /// <summary>
        /// Internal error in Saferpay. Solution: Try again.
        /// </summary>
        [Description("Internal Error")]
        INTERNAL_ERROR,

        /// <summary>
        /// No contract available for the brand / currency combination. Solution: Use another card or change the currency to match an existing contract or have the currency activated for the contract.
        /// </summary>
        [Description("No Contract Available")]
        NO_CONTRACT,

        /// <summary>
        /// No more credits available for this account. Solution: Buy more transaction credits.
        /// </summary>
        [Description("No Credits Available")]
        NO_CREDITS_AVAILABLE,

        /// <summary>
        /// Payer authentication required to proceed (soft decline).
        /// </summary>
        [Description("Payer Authentication Required")]
        PAYER_AUTHENTICATION_REQUIRED,

        /// <summary>
        /// Invalid means of payment (e.g. invalid card).
        /// </summary>
        [Description("Invalid Payment Means")]
        PAYMENTMEANS_INVALID,

        /// <summary>
        /// Unsupported means of payment (e.g. non-SEPA IBAN).
        /// </summary>
        [Description("Payment Means Not Supported")]
        PAYMENTMEANS_NOT_SUPPORTED,

        /// <summary>
        /// No permission (e.g. terminal does not belong to the customer).
        /// </summary>
        [Description("Permission Denied")]
        PERMISSION_DENIED,

        /// <summary>
        /// 3D-secure authentication failed – the transaction must be aborted. Solution: Use another card or means of payment.
        /// </summary>
        [Description("3D-Secure Authentication Failed")]
        _3DS_AUTHENTICATION_FAILED,

        /// <summary>
        /// The token is expired. Solution: Create a new token.
        /// </summary>
        [Description("Token Expired")]
        TOKEN_EXPIRED,

        /// <summary>
        /// The token either does not exist for this customer or was already used.
        /// </summary>
        [Description("Invalid Token")]
        TOKEN_INVALID,

        /// <summary>
        /// The transaction was aborted by the payer.
        /// </summary>
        [Description("Transaction Aborted")]
        TRANSACTION_ABORTED,

        /// <summary>
        /// Transaction already captured.
        /// </summary>
        [Description("Transaction Already Captured")]
        TRANSACTION_ALREADY_CAPTURED,

        /// <summary>
        /// Declined by the processor. Solution: Use another card or check details.
        /// </summary>
        [Description("Transaction Declined")]
        TRANSACTION_DECLINED,

        /// <summary>
        /// Transaction In Wrong State
        /// </summary>
        [Description("Transaction In Wrong State")]
        TRANSACTION_IN_WRONG_STATE,

        /// <summary>
        /// The transaction was not started by the payer. Therefore, no final result for the transaction is available. Solution: Try again later.
        /// </summary>
        [Description("Transaction Not Started")]
        TRANSACTION_NOT_STARTED,

        /// <summary>
        /// Transaction Not Found
        /// </summary>
        [Description("Transaction Not Found")]
        TRANSACTION_NOT_FOUND,

        /// <summary>
        /// The acquirer returned an unexpected error code. Solution: Try again.
        /// </summary>
        [Description("Unexpected Error by Acquirer")]
        UNEXPECTED_ERROR_BY_ACQUIRER,

        /// <summary>
        /// Card details need to be updated in order to have the possibility of a successful payment. Solution: Update card data.
        /// </summary>
        [Description("Update Card Information")]
        UPDATE_CARD_INFORMATION,

        /// <summary>
        /// Validation failed. Solution: Fix the request.
        /// </summary>
        [Description("Validation Failed")]
        VALIDATION_FAILED
    }
}
