using AdvertisingPlatforms.Domain.Models.BaseModels;

namespace AdvertisingPlatforms.Domain.Models
{
    /// <summary>
    /// Location for advertising platforms.
    /// </summary>
    public class Location: Resource
    {
        public List<int> AdvertisingPlatformIds { get; set; } = new();
    }
}
