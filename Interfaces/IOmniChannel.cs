using SaferPay.Models.OmniChannel;

namespace SaferPay.Interfaces;

/// <summary>
/// Omni Channerl<br/><br/>
/// https://saferpay.github.io/jsonapi/index.html#ChapterOmniChannel
/// </summary>
public interface IOmniChannel
{
    #region Sync Methods
    /// <summary>
    /// This function may be used to create an alias by providing a SixTransactionReference.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public InsertAliasResponse InsertAlias(InsertAliasRequest request);

    /// <summary>
    /// This function may be used to acquire a POS authorized or captured transaction by providing a SixTransactionReference. This transaction can then be authorized, canceled, captured or refunded.
    /// </summary>
    /// <param name="request">This request allows to acquire an OmniChannel transaction.</param>
    /// <returns></returns>
    public AcquireTransactionResponse AcquireTransaction(AcquireTransactionRequest request);
    #endregion

    #region Async Methods
    /// <summary>
    /// This function may be used to create an alias by providing a SixTransactionReference.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public Task<InsertAliasResponse> InsertAliasAsync(InsertAliasRequest request);

    /// <summary>
    /// This function may be used to acquire a POS authorized or captured transaction by providing a SixTransactionReference. This transaction can then be authorized, canceled, captured or refunded.
    /// </summary>
    /// <param name="request">This request allows to acquire an OmniChannel transaction.</param>
    /// <returns></returns>
    public Task<AcquireTransactionResponse> AcquireTransactionAsync(AcquireTransactionRequest request);
    #endregion
}
