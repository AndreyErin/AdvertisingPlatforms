using AdvertisingPlatforms.Domain.Models.BaseModels;

namespace AdvertisingPlatforms.Domain.Models
{
    /// <summary>
    /// Advertising platform.
    /// </summary>
    public class AdvertisingPlatform: Resource
    {
        /// <summary>
        /// ID for advertising platform.
        /// </summary>
        public sealed override int Id { get; set; }

        /// <summary>
        /// Create advertising platform.
        /// </summary>
        /// <param name="id">ID for platform.</param>
        public AdvertisingPlatform(int id)
        {
            Id = id;
        }
    }
}
