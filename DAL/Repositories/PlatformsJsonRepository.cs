using Domain.Models;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class PlatformsJsonRepository : IPlatrormsRepository
    {
        private const string filePath = @"/DbFiles/PlatformsDb.json";
        private Dictionary<Location, List<Advertising>> _db;

        public PlatformsJsonRepository()
        {

        _db = ReadDbFromFile(filePath);
        }

        private Dictionary<Location, List<Advertising>> ReadDbFromFile(string filePath)
        {
            //берем данные из файла
            throw new NotImplementedException();
        }

        public Dictionary<Location, List<Advertising>> GetDb()
        {
            return _db;      
        }

        public int UpdateDb(Dictionary<Location, List<Advertising>> newDb)
        {
            bool successUpdateDbFile = UpdateDbFile(filePath);

            if (successUpdateDbFile) 
            {
                _db = newDb;
                return 1;
            }

            return -1;
        }

        private bool UpdateDbFile(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
