using AdvertisingPlatforms.Business.Extensions;
using AdvertisingPlatforms.Domain.Models.BaseModels;

namespace AdvertisingPlatforms.Business.Abstractions.Repositories
{
    /// <summary>
    /// Repository for working with files.
    /// </summary>
    /// <typeparam name="TResource"> notnull, Resource</typeparam>
    public abstract class FileRepository<TResource> where TResource : notnull, Resource
    {
        protected string _dbFilePath = "";

        /// <summary>
        /// Add entity to repository.
        /// </summary>
        /// <param name="entity"></param>
        public void AddToRepository(TResource entity)
        {
            var db = this.GetAllFromFile(_dbFilePath);
            db.Add(entity);
            this.SaveChangesToFile( _dbFilePath,db);
        }

        /// <summary>
        /// Delete from repository.
        /// </summary>
        /// <param name="id">id of entity.</param>
        public void DeleteFromRepository(int id)
        {
            var db = this.GetAllFromFile(_dbFilePath);

            var advertising = db.Find(x => x.Id == id);

            if (advertising != null)
            {
                db.Remove(advertising);
                this.SaveChangesToFile(_dbFilePath, db);
            }
        }

        /// <summary>
        /// Get entity by id form repository.
        /// </summary>
        /// <param name="id">id of entity.</param>
        /// <returns>Entity for success, null for fail.</returns>
        public TResource? GetByIdFromRepository(int id)
        {
            return this.GetAllFromFile(_dbFilePath).Find(x => x.Id == id);
        }

        /// <summary>
        /// Get entities by id form repository.
        /// </summary>
        /// <param name="ids">id of entity.</param>
        /// <returns>List of enties for success, null for fail.</returns>
        public List<TResource> GetByIdFromRepository(List<int> ids)
        {
            return this.GetAllFromFile(_dbFilePath).Where(x => ids.Contains(x.Id)).ToList();
        }

        /// <summary>
        /// Get entity by name form repository.
        /// </summary>
        /// <param name="name">name of entity.</param>
        /// <returns>Entity for success, null for fail</returns>
        public TResource? GetByNameFromRepository(string name)
        {
            return this.GetAllFromFile(_dbFilePath).Find(x => x.Name == name);
        }

        /// <summary>
        /// Owerwrite all entities of repository.
        /// </summary>
        /// <param name="entinies">New entities for owerwrite repository.</param>
        public void ReplaceRepository(IReadOnlyList<TResource> entinies)
        {
            this.SaveChangesToFile(_dbFilePath, entinies);
        }

        /// <summary>
        /// Update entity in repository.
        /// </summary>
        /// <param name="entity">Entity for update.</param>
        public void UpdateInRepository(TResource entity)
        {
            var db = this.GetAllFromFile(_dbFilePath);

            var advertising = db.Find(x => x.Id == entity.Id);

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
