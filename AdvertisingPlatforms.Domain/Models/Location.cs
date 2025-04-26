using AdvertisingPlatforms.Domain.Models.BaseModels;

namespace AdvertisingPlatforms.Domain.Models
{
    /// <summary>
    /// Location for advertising platforms.
    /// </summary>
    public class Location: Resource
    {
        /// <summary>
        /// Advertising IDs for locations.
        /// </summary>
        public List<int> AdvertisingIPlatformds { get; set; } = new();
    }
}
