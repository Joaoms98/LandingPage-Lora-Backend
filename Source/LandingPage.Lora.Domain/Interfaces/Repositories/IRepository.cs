using System.Linq.Expressions;
using LandingPage.Lora.Domain.Entities.Interfaces;

namespace LandingPage.Lora.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        /// <summary>
        /// Add new entity
        /// </summary>
        /// <param name="entity">Entity instance</param>
        /// <exception cref="DuplicateKeyException">Unique key violations.</exception>
        void Add(TEntity entity);

        /// <summary>
        /// Add many entities
        /// </summary>
        /// <param name="entities">Entities list</param>
        void AddMany(IEnumerable<TEntity> entities);

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <returns>Entity instance</returns>
        Task<TEntity> FindAsync<TKey>(TKey id);

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <returns>Entity instance</returns>
        TEntity Find<TKey>(TKey id);

        /// <summary>
        /// Count all async
        /// </summary>
        /// <returns>Entities total</returns>
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null);

        /// <summary>
        /// Count all
        /// </summary>
        /// <returns>Entities total</returns>
        int Count(Expression<Func<TEntity, bool>> predicate = null);

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns>List of entities</returns>
        Task<IEnumerable<TEntity>> AllAsync(Expression<Func<TEntity, bool>> predicate = null);

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns>List of entities</returns>
        IEnumerable<TEntity> All(Expression<Func<TEntity, bool>> predicate = null);

        /// <summary>
        /// Update an entity
        /// </summary>
        /// <param name="entity">Entity instance</param>
        void Update(TEntity entity);

        /// <summary>
        /// Update a list of entities
        /// </summary>
        /// <param name="entities">List of entities</param>
        void UpdateMany(IEnumerable<TEntity> entities);

        /// <summary>
        /// Remove entity
        /// </summary>
        /// <param name="entity">Entity instance</param>
        void Remove(TEntity entity);

        /// <summary>
        /// Remove a list of entities
        /// </summary>
        /// <param name="entities">List of entities</param>
        void RemoveMany(IEnumerable<TEntity> entities);

        /// <summary>
        /// Check if entity exists
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <returns>bool</returns>
        Task<bool> ExistsAsync<TKey>(TKey id);
    }
}