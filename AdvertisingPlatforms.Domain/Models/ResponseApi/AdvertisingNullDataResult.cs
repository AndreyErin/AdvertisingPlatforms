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
        /// <param name="errorMessage">ErrorMessage for response.</param>
        public AdvertisingNullDataResult(string errorMessage) : base(false)
        {
            ErrorMessage = errorMessage;
        }
    }
    
}
