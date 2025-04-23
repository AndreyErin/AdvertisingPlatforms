namespace AdvertisingPlatforms.Domain.Models
{
    public class AdvertisingUpdateResult
    {
        public int CountAdvertisingPlatforms { get; }
        public int CountLocations { get; }

        public AdvertisingUpdateResult(int countAdvertisingPlatforms, int countLocations)
        {
            CountAdvertisingPlatforms = countAdvertisingPlatforms;
            CountLocations = countLocations;
        }
    }
}
