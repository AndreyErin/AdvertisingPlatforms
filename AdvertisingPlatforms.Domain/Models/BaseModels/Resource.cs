namespace AdvertisingPlatforms.Domain.Models.BaseModels
{
    /// <summary>
    /// Basic type for resources.
    /// </summary>
    public abstract class Resource
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
    }
}
