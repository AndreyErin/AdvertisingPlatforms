using AdvertisingPlatforms.DAL.Const;
using AdvertisingPlatforms.DAL.Interfaces;
using AdvertisingPlatforms.Domain.Exeptions;
using AdvertisingPlatforms.Domain.Models.BaseModels;

namespace AdvertisingPlatforms.DAL.FileAccess
{
    /// <summary>
    /// Repository for working with files.
    /// </summary>
    /// <typeparam name="TResource">Resource</typeparam>
    public class FileRepository<TResource> where TResource : Resource
    {
        public readonly string FilePath;

        public FileRepository(string filePath)
        {
            FilePath = filePath;
        }

        /// <summary>
        /// Add entity to repository.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="repositoryReader">Reader for repository.</param>
        /// <param name="repositoryWriter">Writer for repository.</param>
        public void AddToRepository(TResource entity, IRepositoryReader repositoryReader, IRepositoryWriter repositoryWriter)
        {
            var repositoryEntities = repositoryReader.GetAllFromFile<TResource>(FilePath);
            repositoryEntities.Add(entity);
            repositoryWriter.SaveChangesToFile( FilePath,repositoryEntities);
        }

        /// <summary>
        /// Delete from repository.
        /// </summary>
        /// <param name="id">id of entity.</param>
        /// <param name="repositoryReader">Reader for repository.</param>
        /// <param name="repositoryWriter">Writer for repository.</param>
        public void DeleteFromRepository(int id, IRepositoryReader repositoryReader, IRepositoryWriter repositoryWriter)
        {
            var repositoryEntities = repositoryReader.GetAllFromFile<TResource>(FilePath);

            var entityForDelete = repositoryEntities.Find(x => x.Id == id);

            if (entityForDelete == null) return;
            
            repositoryEntities.Remove(entityForDelete);
            repositoryWriter.SaveChangesToFile(FilePath, repositoryEntities);
        }

        /// <summary>
        /// Get entity by id form repository.
        /// </summary>
        /// <param name="id">id of entity.</param>
        /// <param name="repositoryReader">Reader for repository.</param>
        /// <returns>Entity for success, null for fail.</returns>
        public TResource? GetByIdFromRepository(int id, IRepositoryReader repositoryReader)
        {
            return repositoryReader.GetAllFromFile<TResource>(FilePath).Find(x => x.Id == id);
        }

        /// <summary>
        /// Get entities by id form repository.
        /// </summary>
        /// <param name="ids">id of entity.</param>
        /// <param name="repositoryReader">Reader for repository.</param>
        /// <returns>List of entities for success, empty collection for fail.</returns>
        public List<TResource> GetByIdFromRepository(List<int> ids, IRepositoryReader repositoryReader)
        {
            return repositoryReader.GetAllFromFile<TResource>(FilePath).Where(x => ids.Contains(x.Id)).ToList();
        }

        /// <summary>
        /// Overwrite all entities of repository.
        /// </summary>
        /// <param name="entities">New entities for overwrite repository.</param>
        /// <param name="repositoryWriter">Writer for repository.</param>
        public void ReplaceRepository(IReadOnlyList<TResource> entities, IRepositoryWriter repositoryWriter)
        {
            repositoryWriter.SaveChangesToFile(FilePath, entities);
        }

        /// <summary>
        /// Update entity in repository.
        /// </summary>
        /// <param name="entity">Entity for update.</param>
        /// <param name="repositoryReader">Reader for repository.</param>
        /// <param name="repositoryWriter">Writer for repository.</param>
        /// <exception cref="BusinessException"></exception>
        public void UpdateInRepository(TResource entity, IRepositoryReader repositoryReader, IRepositoryWriter repositoryWriter)
        {
            var repositoryEntities = repositoryReader.GetAllFromFile<TResource>(FilePath);

            var entityForUpdate = repositoryEntities.Find(x => x.Id == entity.Id);

            if (entityForUpdate == null)
                throw new BusinessException(ErrorConstants.EntityNotFound);

            entityForUpdate = entity;
            repositoryWriter.SaveChangesToFile(FilePath, repositoryEntities);
        }
    }
}
