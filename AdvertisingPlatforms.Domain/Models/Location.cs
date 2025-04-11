using AdvertisingPlatforms.Domain.Models.BaseModels;

namespace AdvertisingPlatforms.Domain.Models
{
    /// <summary>
    /// Location for advertising.
    /// </summary>
    public class Location: Resource
    {
        public List<int>? AdvertisingIds { get; set; }
    }
}
