using SaferPay.Models.Batch;

namespace SaferPay.Interfaces;

/// <summary>
/// Batch<br/><br/>
/// https://saferpay.github.io/jsonapi/index.html#ChapterBatch
/// </summary>
public interface IBatch
{
    #region Sync Methods
    public BatchResponse Close(BatchRequest request);
    #endregion

    #region Async Methods
    public Task<BatchResponse> CloseAsync(BatchRequest request);
    #endregion
}
