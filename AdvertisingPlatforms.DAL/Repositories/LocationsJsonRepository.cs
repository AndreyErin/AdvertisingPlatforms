using AdvertisingPlatforms.Domain.Interfaces.Repositories;
using AdvertisingPlatforms.Domain.Models;
using System.Text.Json;

namespace AdvertisingPlatforms.DAL.Repositories
{
    /// <summary>
    /// Repository of locations for working with a json file.
    /// </summary>
    public class LocationsJsonRepository : ILocationsRepository
    {
        private string filePath;

        public LocationsJsonRepository()
        {
            filePath = Directory.GetParent(Directory.GetCurrentDirectory()) + @"\AdvertisingPlatforms.DAL\JsonDBs\LocationsDb.json";
        }

        public void Add(Location entity)
        {
            var db = ReadDb();
            db.Add(entity);
            WriteDb(db);
        }

        public void Delete(int id)
        {
            var db = ReadDb();
            var location = db.Find(x=>x.Id == id);
            if (location != null) 
            {
                db.Remove(location);
                WriteDb(db);
            }
        }

        public Location? Get(int id)
        {
            return ReadDb().Find(x=>x.Id == id);
        }

        public List<Location> GetAll()
        {
            return ReadDb();
        }

        public void Update(Location entity)
        {
            var db = ReadDb();

            Location? location = db.Find(x => x.Id == entity.Id);

            if (location != null)
            {
                location = entity;
                WriteDb(db);
            }
            else
            {
                //исключение
            }
        }

        private List<Location> ReadDb()
        {
            using StreamReader sr = new StreamReader(filePath);
            var jsonDb = sr.ReadToEnd();

            var result = JsonSerializer.Deserialize<List<Location>>(jsonDb);

            if (result == null)
            {
                //исключение
            }

            return result;
        }
        private void WriteDb(List<Location> newDb)
        {
            var newDbJson = JsonSerializer.Serialize(newDb);

            if (newDbJson != null)
            {
                using StreamWriter sw = new StreamWriter(filePath, false);

                sw.Write(newDbJson);
            }
            else
            {
                //исключение
            }
        }
    }
}
