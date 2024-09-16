using System.Linq.Expressions;

namespace Searching_Tool_Assignment.IRepositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task Add(TEntity entity);

        Task AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);

        Task<TEntity?> Get(int id);

        Task<IEnumerable<TEntity>> GetAll();

        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);

        void Update(TEntity entity);
    }
}
