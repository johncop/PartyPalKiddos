using System.Linq.Expressions;

namespace PartyKid;

public interface IExtensionServices<TEntity> where TEntity : class
{
    IQueryable<TEntity> Query(Expression<Func<TEntity, bool>>? filter = null, Expression<Func<TEntity, object>>? includeEntities = null, bool disableChangeTracker = true);
    Task<string> DeleteAsync(TEntity entity);
}
