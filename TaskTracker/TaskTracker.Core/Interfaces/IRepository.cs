using TaskTracker.Core.Entities;

namespace TaskTracker.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Retrieves entity from the database
        /// </summary>
        /// <param name="id">Entity's id</param>
        /// <returns></returns>
        T? GetById(int id);

        /// <summary>
        /// Retrieves all entities from the database
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Adds entity to the database
        /// </summary>
        /// <param name="entity">Entity to add</param>
        void Add(T entity);

        /// <summary>
        /// Updates entity in the database
        /// </summary>
        /// <param name="entity">Entity to update</param>
        void Update(T entity);

        /// <summary>
        /// Marks entity as removed in the database
        /// </summary>
        /// <param name="id">Entity's id</param>
        void Delete(int id);
    }
}
