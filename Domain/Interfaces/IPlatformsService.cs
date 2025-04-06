namespace Domain.Interfaces
{
    public interface IPlatformsService
    {
        public List<string> GetPlatforms(string location);
        public int SetDbPlatforms(Dictionary<string, List<string>> db);
    }
}
