using SaferPay.Models.SecureData;

namespace SaferPay.Interfaces;

/// <summary>
/// Secure Card Data<br/><br/>
/// https://saferpay.github.io/jsonapi/index.html#ChapterAliasStore
/// </summary>
public interface ISecureCardData
{
    #region Sync Methods
    /// <summary>
    /// This function may be used to insert an alias without knowledge about the card details. Therefore a redirect of the customer is required.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public AliasInsertResponse AliasInsert(AliasInsertRequest request);

    /// <summary>
    /// This method may be used to inquire the Alias Id and further information after a successful Alias Insert call. This function can be called up to 24 hours after the transaction was initialized.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public AssertInsertResponse AssertInsert(AssertInsertRequest request);

    /// <summary>
    /// This method may be used to insert an alias directly with card-data collected by using your own HTML form.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public InsertDirectResponse InsertDirect(InsertDirectRequest request);

    /// <summary>
    /// This method may be used to update an alias' lifetime and / or its credit card expiry date
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public AliasUpdateResponse AliasUpdate(AliasUpdateRequest request);

    /// <summary>
    /// This method may be used to delete previously inserted aliases.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public AliasDeleteResponse AliasDelete(AliasDeleteRequest request);

    /// <summary>
    /// This method can be used to get the latest details of an alias
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public AliasInquireResponse AliasInquire(AliasInquireRequest request);
    #endregion

    #region Async Methods
    /// <summary>
    /// This function may be used to insert an alias without knowledge about the card details. Therefore a redirect of the customer is required.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public Task<AliasInsertResponse> AliasInsertAsync(AliasInsertRequest request);

    /// <summary>
    /// This method may be used to inquire the Alias Id and further information after a successful Alias Insert call. This function can be called up to 24 hours after the transaction was initialized.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public Task<AssertInsertResponse> AssertInsertAsync(AssertInsertRequest request);

    /// <summary>
    /// This method may be used to insert an alias directly with card-data collected by using your own HTML form.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public Task<InsertDirectResponse> InsertDirectAsync(InsertDirectRequest request);

    /// <summary>
    /// This method may be used to update an alias' lifetime and / or its credit card expiry date
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public Task<AliasUpdateResponse> AliasUpdateAsync(AliasUpdateRequest request);

    /// <summary>
    /// This method may be used to delete previously inserted aliases.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public Task<AliasDeleteResponse> AliasDeleteAsync(AliasDeleteRequest request);

    /// <summary>
    /// This method can be used to get the latest details of an alias
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public Task<AliasInquireResponse> AliasInquireAsync(AliasInquireRequest request);
    #endregion
}
