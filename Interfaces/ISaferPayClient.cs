using SaferPay.Models.Core;

namespace SaferPay.Interfaces;

/// <summary>
/// SaferPay Client Interface
/// </summary>
public interface ISaferPayClient : IDisposable
{
    /// <summary>
    /// Async Send
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    /// <typeparam name="TRequest"></typeparam>
    /// <param name="path"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<TResponse> SendAsync<TResponse, TRequest>(string path, TRequest request) where TRequest : RequestBase where TResponse : ResponseBase;

    /// <summary>
    /// Sync Send
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    /// <typeparam name="TRequest"></typeparam>
    /// <param name="path"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    TResponse Send<TResponse, TRequest>(string path, TRequest request) where TRequest : RequestBase where TResponse : ResponseBase;

    /// <summary>
    /// Transaction Api Interface<br/><br/>
    /// Returns Transaction Api Instance
    /// </summary>
    public ITransaction Transaction { get; }

    /// <summary>
    /// Payment Page Api Interface<br/><br/>
    /// Returns Payment Page Api Instance
    /// </summary>
    public IPaymentPage PaymentPage { get; }

    /// <summary>
    /// Secure Card Data Api Interface<br/><br/>
    /// Returns Secure Card Data Api Instance
    /// </summary>
    public ISecureCardData SecureCardData { get; }

    /// <summary>
    /// Batch Api Interface<br/><br/>
    /// Returns Batch Api Instance
    /// </summary>
    public IBatch Batch { get; }

    /// <summary>
    /// Omni Channel Api Interface<br/><br/>
    /// Returns Omni Channel Api Instance
    /// </summary>
    public IOmniChannel OmniChannel { get; }

}
