namespace AdvertisingPlatforms.Domain.Models.BaseModels
{
    /// <summary>
    /// Basic type for resources.
    /// </summary>
    public abstract class Resource
    {
        /// <summary>
        /// ID of resource.
        /// </summary>
        public abstract int Id { get; set; }
    }
}
