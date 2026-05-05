using SaferPay.Models.Core;
using SaferPay.Models.Management;

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



    #region RestMethods
    TResponse Get<TResponse>(string path) where TResponse : RestResponseBase;
    Task<TResponse> GetAsync<TResponse>(string path) where TResponse : RestResponseBase;


    TResponse Get<TResponse, TRequest>(string path, TRequest request) where TRequest : RestRequestBase where TResponse : RestResponseBase;
    Task<TResponse> GetAsync<TResponse, TRequest>(string path, TRequest request) where TRequest : RestRequestBase where TResponse : RestResponseBase;


    TResponse Post<TResponse>(string path) where TResponse : RestResponseBase;
    Task<TResponse> PostAsync<TResponse>(string path) where TResponse : RestResponseBase;


    TResponse Post<TResponse, TRequest>(string path, TRequest request) where TRequest : RestRequestBase where TResponse : RestResponseBase;
    Task<TResponse> PostAsync<TResponse, TRequest>(string path, TRequest request) where TRequest : RestRequestBase where TResponse : RestResponseBase;


    TResponse Delete<TResponse>(string path) where TResponse : RestResponseBase;
    Task<TResponse> DeleteAsync<TResponse>(string path) where TResponse : RestResponseBase;
    #endregion



    public string CustomerId { get; }


    public string TerminalId { get; }

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


    /// <summary>
    /// This interface offers REST based access to various management features. This enables customers to integrate those features into their systems on a technical level.
    /// </summary>
    public IManagementApi ManagementApi { get; }

}
