using AdvertisingPlatforms.Domain.Models.BaseModels;

namespace AdvertisingPlatforms.Domain.Models.ResponseApi
{
    /// <summary>
    /// Model for return result of ApiController.
    /// </summary>
    /// <typeparam name="TApiResultData">Data for response.</typeparam>
    public class ResponseApi<TApiResultData> where TApiResultData : ApiResultData
    {
        /// <summary>
        /// Success of fail response.
        /// </summary>
        public bool Success { get; }

        /// <summary>
        /// Message for response.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Data for response.
        /// </summary>
        public TApiResultData? Data { get; }

        /// <summary>
        /// Create new model.
        /// </summary>
        /// <param name="success">Success of fail response.</param>
        /// <param name="message">Message for response.</param>
        /// <param name="data">Data for response.</param>
        public ResponseApi(bool success, string message, TApiResultData? data = null)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}
