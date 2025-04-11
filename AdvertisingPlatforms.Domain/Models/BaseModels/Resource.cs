namespace AdvertisingPlatforms.Domain.Models.BaseModels
{
    public abstract class Resource
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
    }
}
