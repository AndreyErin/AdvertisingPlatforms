using AdvertisingPlatforms.Domain.Models.BaseModels;

namespace AdvertisingPlatforms.Domain.Models
{
    /// <summary>
    /// Location for advertising platforms.
    /// </summary>
    public class Location: Resource
    {
        /// <summary>
        /// ID for location.
        /// </summary>
        public sealed override int Id { get; set; }

        /// <summary>
        /// Create location.
        /// </summary>
        /// <param name="id">ID for location.</param>
        public Location(int id)
        {
            Id = id;
        }
    }
}
