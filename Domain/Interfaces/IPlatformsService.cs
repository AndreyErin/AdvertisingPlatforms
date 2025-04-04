using Domain.Models;

namespace Domain.Interfaces
{
    public interface IPlatformsService
    {
        public List<Advertising> GetPlatforms(string location);
        public int SetDbPlatforms(Dictionary<Location, List<Advertising>> newDb);
    }
}
