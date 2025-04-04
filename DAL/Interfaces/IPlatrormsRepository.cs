using Domain.Models;

namespace DAL.Interfaces
{
    public interface IPlatrormsRepository
    {
        Dictionary<Location, List<Advertising>> GetDb();
        int UpdateDb(Dictionary<Location, List<Advertising>> newDb);
    }
}
