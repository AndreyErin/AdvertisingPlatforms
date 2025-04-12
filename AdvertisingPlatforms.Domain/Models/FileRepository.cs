using AdvertisingPlatforms.Domain.Extensions;
using AdvertisingPlatforms.Domain.Models.BaseModels;

namespace AdvertisingPlatforms.Domain.Models
{
    //TODO - add xml coments
    public abstract class FileRepository<T> where T : notnull, Resource
    {
        protected string _dbFilePath = "";

        public void AddToRepository(T entity)
        {
            var db = this.GetAllFromFile(_dbFilePath);
            db.Add(entity);
            this.SaveChangesToFile( _dbFilePath,db);
        }

        public void DeleteFromRepository(int id)
        {
            var db = this.GetAllFromFile(_dbFilePath);

            T? advertising = db.Find(x => x.Id == id);

            if (advertising != null)
            {
                db.Remove(advertising);
                this.SaveChangesToFile(_dbFilePath, db);
            }
        }

        public T? GetByIdFromRepository(int id)
        {
            return this.GetAllFromFile(_dbFilePath).Find(x => x.Id == id);
        }

        public T? GetByNameFromRepository(string name)
        {
            return this.GetAllFromFile(_dbFilePath).Find(x => x.Name == name);
        }

        public void OwerWriteDbOfRepository(List<T> entinies)
        {
            int counter = 1;

            foreach (var entity in entinies)
            {
                entity.Id = counter;
                counter++;
            }

            this.SaveChangesToFile(_dbFilePath, entinies);
        }

        public void UpdateInRepository(T entity)
        {
            var db = this.GetAllFromFile(_dbFilePath);

            T? advertising = db.Find(x => x.Id == entity.Id);

            if (advertising != null)
            {
                advertising = entity;
                this.SaveChangesToFile(_dbFilePath, db);
            }
            else
            {
                //Exeption
            }
        }
    }
}
