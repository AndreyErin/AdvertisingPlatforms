using AdvertisingPlatforms.Domain.Models.BaseModels;

namespace AdvertisingPlatforms.Domain.Models
{
    /// <summary>
    /// Model that displays the availability of advertising platforms for a location.
    /// </summary>
    public class AdvertisingInLocation: Resource
    {
        /// <summary>
        /// ID of model.
        /// </summary>
        public override int Id { get; set; }
        /// <summary>
        /// ID of location.
        /// </summary>
        public int LocationId { get; set; }
        /// <summary>
        /// IDs of advertising platforms  available for the location.
        /// </summary>
        public List<int> AdvertisingIds { get; set; }

        /// <summary>
        /// Create a model that displays the availability of advertising platforms for a location.
        /// </summary>
        /// <param name="id">ID of model.</param>
        /// <param name="locationId">ID of location.</param>
        /// <param name="advertisingIds">IDs of advertising platforms  available for the location.</param>
        public AdvertisingInLocation(int id, int locationId, List<int> advertisingIds)
        {
            Id = id;
            LocationId = locationId;
            AdvertisingIds = advertisingIds;
        }
    }
}
