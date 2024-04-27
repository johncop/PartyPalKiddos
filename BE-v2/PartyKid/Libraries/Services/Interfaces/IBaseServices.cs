using System.Linq.Expressions;

namespace PartyKid;

public interface IBaseServices<TEntity> where TEntity : class
{
    Task<IList<TReponse>> GetAllAsync<TReponse>(Expression<Func<TEntity, bool>>? filter = null, Expression<Func<TEntity, object>>? includeEntities = null, bool disableChangeTracker = true);
    IList<TEntity> GetAll();
    Task<TEntity> Find(Expression<Func<TEntity, bool>> filter);
    Task<IList<TResponse>> Search<TResponse>(Expression<Func<TEntity, bool>>? filter = null, Expression<Func<TEntity, object>>? includeEntities = null, bool disableChangeTracker = true);
    IQueryable<TEntity> Query(Expression<Func<TEntity, bool>>? filter = null, Expression<Func<TEntity, object>>? includeEntities = null, bool disableChangeTracker = true);
    Task<string> Create(TEntity entity);
    Task<TEntity> Update(TEntity entity);
    Task<string> Delete(TEntity entity);
    Task<string> DeleteAsync(TEntity entity);
}
