namespace AdvertisingPlatforms.Domain.Models.BaseModels
{
    /// <summary>
    /// Model for return result of ApiController.
    /// </summary>
    public abstract class BaseResponse
    {
        /// <summary>
        /// Success of fail response.
        /// </summary>
        public bool Success { get; }

        /// <summary>
        /// Initialize base constructor.
        /// </summary>
        /// <param name="success">Success of fail response.</param>
        protected BaseResponse(bool success)
        {
            Success = success;
        }
    }
}
