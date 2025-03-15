namespace SaferPay.Enums;

public enum TokenizationStatus
{
    SUCCESSFUL, 
    FAILED, 
    SCHEME_NOT_SUPPORTED, 
    ACQUIRER_NOT_SUPPORTED, 
    NOT_PERFORMED, 
    DENIED_BY_SCHEME
}
