using AdvertisingPlatforms.Domain.Models.BaseModels;

namespace AdvertisingPlatforms.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Standart interface for repository.
    /// </summary>
    /// <typeparam name="T">Type of resource.</typeparam>
    public interface IRepository<T> where T :notnull , Resource
    {
        /// <summary>
        /// Get all entitis of repository.
        /// </summary>
        /// <returns>Return List of entities.</returns>
        List<T> GetAll();

        /// <summary>
        /// Return entity for id.
        /// </summary>
        /// <param name="id">Id of entity.</param>
        /// <returns>Return entity for success, null for fail.</returns>
        T? Get(int id);

        /// <summary>
        /// Add entity.
        /// </summary>
        /// <param name="entity">New entity.</param>
        /// <returns>Return 1 for success, -1 for fail.</returns>
        void Add(T entity);

        /// <summary>
        /// Update entity.
        /// </summary>
        /// <param name="entity">Entity for update.</param>
        /// <returns>Return updated entity for success, null for fail.</returns>
        void Update(T entity);

        /// <summary>
        /// Delete entity.
        /// </summary>
        /// <param name="entity">Entity for delete.</param>
        /// <returns>Return 1 for success, -1 for fail</returns>
        void Delete(int id);
    }
}
