using AdvertisingPlatforms.DAL.FileAccess;
using AdvertisingPlatforms.DAL.Interfaces;
using AdvertisingPlatforms.Domain.Configuration;
using AdvertisingPlatforms.Domain.Models.BaseModels;

namespace AdvertisingPlatforms.DAL.Repositories.Base
{
    /// <summary>
    /// Facade for work with FileRepository, RepositoryReader, RepositoryWriter.
    /// </summary>
    /// <typeparam name="TResource">Resource.</typeparam>
    public class Repository<TResource> where TResource: Resource
    {
        private readonly FileRepository<TResource> _repository;
        private readonly IRepositoryReader _repositoryReader;
        private readonly IRepositoryWriter _repositoryWriter;
        public Repository()
        {
            var filePath = String.Empty;

            switch (typeof(TResource).Name)
            {
                case "Location":
                    filePath = Config.LocationsDbPath;
                    break;
                case "AdvertisingPlatform":
                    filePath = Config.AdvertisingPlatformsDbPath;
                    break;
            }

            _repository = new FileRepository<TResource>(filePath);
            _repositoryReader = new RepositoryReader();
            _repositoryWriter = new RepositoryWriter();
        }

        /// <summary>
        /// Add entity to repository.
        /// </summary>
        /// <param name="entity"></param>
        public void AddToRepository(TResource entity)
        {
            _repository.AddToRepository(entity, _repositoryReader, _repositoryWriter);
        }

        /// <summary>
        /// Delete from repository.
        /// </summary>
        /// <param name="id">id of entity.</param>
        public void DeleteFromRepository(int id)
        {
            _repository.DeleteFromRepository(id, _repositoryReader, _repositoryWriter);
        }

        /// <summary>
        /// Get entity by id form repository.
        /// </summary>
        /// <param name="id">id of entity.</param>
        /// <returns>Entity for success, null for fail.</returns>
        public TResource? GetByIdFromRepository(int id)
        {
            return _repository.GetByIdFromRepository(id, _repositoryReader);
        }

        /// <summary>
        /// Get entities by id form repository.
        /// </summary>
        /// <param name="ids">id of entity.</param>
        /// <returns>List of entities for success, null for fail.</returns>
        public List<TResource> GetByIdFromRepository(List<int> ids)
        {
            return _repository.GetByIdFromRepository(ids, _repositoryReader);
        }

        /// <summary>
        /// Get entity by name form repository.
        /// </summary>
        /// <param name="name">name of entity.</param>
        /// <returns>Entity for success, null for fail</returns>
        public TResource? GetByNameFromRepository(string name)
        {
            return _repository.GetByNameFromRepository(name, _repositoryReader);
        }

        /// <summary>
        /// Overwrite all entities of repository.
        /// </summary>
        /// <param name="entities">New entities for overwrite repository.</param>
        public void ReplaceRepository(IReadOnlyList<TResource> entities)
        {
            _repository.ReplaceRepository(entities, _repositoryWriter);
        }

        /// <summary>
        /// Update entity in repository.
        /// </summary>
        /// <param name="entity">Entity for update.</param>
        public void UpdateInRepository(TResource entity)
        {
            _repository.UpdateInRepository(entity, _repositoryReader, _repositoryWriter);
        }
    }
}
