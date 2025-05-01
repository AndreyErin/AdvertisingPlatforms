using AdvertisingPlatforms.Domain.Models.BaseModels;

namespace AdvertisingPlatforms.Domain.Models.ResponseApi
{
    /// <summary>
    /// Null data for response.
    /// </summary>
    public class AdvertisingNullDataResult: BaseResponse
    {
        /// <summary>
        /// ErrorMessage for response.
        /// </summary>
        public string ErrorMessage { get; }

        /// <summary>
        /// Create new model.
        /// </summary>
        /// <param name="success">Success of fail response.</param>
        /// <param name="errorMessage">ErrorMessage for response.</param>
        public AdvertisingNullDataResult(bool success, string errorMessage) : base(success)
        {
            ErrorMessage = errorMessage;
        }
    }
    
}
