namespace AdvertisingPlatforms.Domain.Models
{
    /// <summary>
    /// The type contains advertising and locations obtained from the file.
    /// </summary>
    public class DataFromFile
    {
        public List<AdvertisingPlatform> AdvertisingPlatforms { get; set; }
        public List<Location> Locations { get; set; }

        public DataFromFile(List<AdvertisingPlatform> advertisingPlatforms, List<Location> locations)
        {
            AdvertisingPlatforms = advertisingPlatforms;
            Locations = locations;
        }
    }
}
