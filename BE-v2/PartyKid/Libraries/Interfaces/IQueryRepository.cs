using System.Linq.Expressions;

namespace PartyKid;

public interface IQueryRepository<TEntity> where TEntity : class
{
    IList<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null, Expression<Func<TEntity, object>>? includeEntities = null, bool disableChangeTracker = true);
    Task<IList<T>> GetAllAsync<T>(Expression<Func<TEntity, bool>>? filter = null, Expression<Func<TEntity, object>>? includeEntities = null, bool disableChangeTracker = true);
    IQueryable<TEntity> Find(Expression<Func<TEntity, bool>>? filter = null, Expression<Func<TEntity, object>>? includeEntities = null, bool disableChangeTracker = true);
    IQueryable<TEntity> InitQuery(Expression<Func<TEntity, bool>>? filter = null, Expression<Func<TEntity, object>>? includeEntities = null, bool disableChangeTracker = true);
}
