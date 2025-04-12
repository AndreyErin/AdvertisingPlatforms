using AdvertisingPlatforms.Domain.Models.BaseModels;
using System.Text.Json;

namespace AdvertisingPlatforms.Domain.Models
{
    //TODO - add xml coments
    public abstract class FileRepository<T> where T : notnull, Resource
    {
        protected string _dbFilePath = "";

        public void AddToRepository(T entity)
        {
            var db = ReadDb();
            db.Add(entity);
            WriteDb(db);
        }

        public void DeleteFromRepository(int id)
        {
            var db = ReadDb();

            T? advertising = db.Find(x => x.Id == id);

            if (advertising != null)
            {
                db.Remove(advertising);
                WriteDb(db);
            }
        }

        public T? GetByIdFromRepository(int id)
        {
            return ReadDb().Find(x => x.Id == id);
        }

        public T? GetByNameFromRepository(string name)
        {
            return ReadDb().Find(x => x.Name == name);
        }

        public List<T> GetAllFromRepository()
        {
            return ReadDb();
        }

        public void OwerWriteDbOfRepository(List<T> entinies)
        {
            int counter = 1;

            foreach (var entity in entinies)
            {
                entity.Id = counter;
                counter++;
            }

            WriteDb(entinies);
        }

        public void UpdateInRepository(T entity)
        {
            var db = ReadDb();

            T? advertising = db.Find(x => x.Id == entity.Id);

            if (advertising != null)
            {
                advertising = entity;
                WriteDb(db);
            }
            else
            {
                //Exeption
            }
        }

        private List<T> ReadDb()
        {
            using StreamReader sr = new StreamReader(_dbFilePath);
            var jsonDb = sr.ReadToEnd();

            var result = JsonSerializer.Deserialize<List<T>>(jsonDb);

            if (result == null)
            {
                //Exeption
            }

            return result;
        }
        private void WriteDb(List<T> newDb)
        {
            var newDbJson = JsonSerializer.Serialize(newDb);

            if (newDbJson != null)
            {
                using StreamWriter sw = new StreamWriter(_dbFilePath, false);

                sw.Write(newDbJson);
            }
            else
            {
                //Exeption
            }
        }
    }
}
