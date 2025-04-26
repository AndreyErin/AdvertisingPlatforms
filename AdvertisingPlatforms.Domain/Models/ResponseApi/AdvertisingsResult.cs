using AdvertisingPlatforms.Domain.Models.BaseModels;

namespace AdvertisingPlatforms.Domain.Models.ResponseApi
{
    /// <summary>
    /// Collection advertising for response.
    /// </summary>
    public class AdvertisingsResult: ApiResultData
    {
        /// <summary>
        /// Collection advertidings.
        /// </summary>
        public List<string> Advertisings { get; }

        /// <summary>
        /// Create new model.
        /// </summary>
        /// <param name="advertisings">Collection advertidings.</param>
        public AdvertisingsResult(List<string> advertisings)
        {
            Advertisings = advertisings;
        }
    }
}
