using AdvertisingPlatforms.Domain.Interfaces.Repositories;
using AdvertisingPlatforms.Domain.Models;
using System.Text.Json;

namespace AdvertisingPlatforms.DAL.Repositories
{
    /// <summary>
    /// Repository of advertisings for working with a json file.
    /// </summary>
    public class AdvertisingsJsonRepository : IAdvertisingsRepository
    {
        private string filePath;

        public AdvertisingsJsonRepository()
        {
            filePath = Directory.GetParent(Directory.GetCurrentDirectory()) + @"\AdvertisingPlatforms.DAL\JsonDBs\AdvertisingsDb.json";
        }

        public void Add(Advertising entity)
        {
            var db = ReadDb();
            db.Add(entity);
            WriteDb(db);
        }

        public void Delete(int id)
        {
            var db = ReadDb();

            Advertising? advertising = db.Find(x=>x.Id == id);

            if (advertising != null) 
            {
                db.Remove(advertising);
                WriteDb(db);
            }
           
        }

        public Advertising? Get(int id)
        {
            return ReadDb().Find(x=>x.Id == id);
        }

        public List<Advertising> GetAll()
        {
            return ReadDb();
        }

        public void Update(Advertising entity)
        {
            var db = ReadDb();

            Advertising? advertising = db.Find(x => x.Id == entity.Id);

            if (advertising != null)
            {
                advertising = entity;
                WriteDb(db);
            }
            else
            {
                //исключение
            }
        }

        private List<Advertising> ReadDb() 
        {
            using StreamReader sr = new StreamReader(filePath);
            var jsonDb = sr.ReadToEnd();

            var result = JsonSerializer.Deserialize<List<Advertising>>(jsonDb);

            if (result == null) 
            {
                //исключение
            }

            return result;
        }
        private void WriteDb(List<Advertising> newDb) 
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
