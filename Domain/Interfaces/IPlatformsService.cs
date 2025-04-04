namespace Domain.Interfaces
{
    public interface IPlatformsService
    {
        public List<string> GetPlatforms(string region);
        public int SetDbPlatforms(Dictionary<string, string> db);
    }
}
