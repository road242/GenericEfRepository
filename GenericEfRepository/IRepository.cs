namespace GenericEfRepository
{
    using System.Linq;

    /// <summary>
    /// Interface with main ef access methods
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Get all objects as IQueryable to do further filtering
        /// </summary>
        /// <returns>All objects of entity</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Get all objects according to given object
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        IQueryable<T> GetAll(T filter);

        /// <summary>
        /// Retrieves entity by it's identifier
        /// </summary>
        /// <param name="id">the identifier of the object</param>
        /// <returns>entity found or null if no object could be found</returns>
        T GetById(object id);

        /// <summary>
        /// Attach object
        /// </summary>
        /// <param name="entity">entity to attach</param>
        /// <returns></returns>
        object Add(T entity);

        /// <summary>
        /// Update object
        /// </summary>
        /// <param name="entity">Object to be updated</param>
        void Update(T entity);

        /// <summary>
        /// Remove object
        /// </summary>
        /// <param name="entity">Object to be detached</param>
        void Delete(T entity);

        /// <summary>
        /// Remove object by its identifier
        /// </summary>
        /// <param name="id">id ob entity</param>
        void Delete(string id);
    }
}