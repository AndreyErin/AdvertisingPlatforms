namespace AdvertisingPlatforms.Business.Models
{
    public class MessageOfReplace
    {
        public int CountAdvertisingPlatforms { get;}
        public int CountLocations { get;}

        public MessageOfReplace(int countAdvertisingPlatforms, int countLocations)
        {
            CountAdvertisingPlatforms = countAdvertisingPlatforms;
            CountLocations = countLocations;
        }
    }
}
