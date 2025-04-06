namespace Domain.Interfaces
{
    public interface IPlatformsRepository
    {
        Dictionary<string, List<string>>? GetDb();
        int SetDb(Dictionary<string, List<string>> newDb);
    }
}
