using AdvertisingPlatforms.Domain.Models.BaseModels;

namespace AdvertisingPlatforms.Domain.Models.ResponseApi
{
    /// <summary>
    /// Collection advertising for response.
    /// </summary>
    public class AdvertisingsResult: BaseResponse
    {
        /// <summary>
        /// Collection advertising platforms.
        /// </summary>
        public List<string> Advertisings { get; }

        /// <summary>
        /// Create new model.
        /// </summary>

        /// <param name="advertisings">Collection advertising platforms.</param>
        public AdvertisingsResult(List<string> advertisings) : base(true)
        {
            Advertisings = advertisings;
        }
    }
}
