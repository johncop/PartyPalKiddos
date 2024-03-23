using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace PartyKid;

public class QueryRepository<TEntity> : IQueryRepository<TEntity> where TEntity : class
{
    protected readonly PartyKidDbContext _dbContext;
    private readonly DbSet<TEntity> _dbSet;
    private readonly AutoMapper.IConfigurationProvider _config;

    public QueryRepository(PartyKidDbContext dbContext, AutoMapper.IConfigurationProvider config)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<TEntity>();
        _config = config;
    }

    public IList<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null, Expression<Func<TEntity, object>>? includeEntities = null, bool disableChangeTracker = true)
    {
        return InitQuery(filter, includeEntities, disableChangeTracker).ToList();
    }

    public async Task<IList<T>> GetAllAsync<T>(Expression<Func<TEntity, bool>>? filter = null, Expression<Func<TEntity, object>>? includeEntities = null, bool disableChangeTracker = true)
    {
        return await InitQuery(filter, includeEntities, disableChangeTracker).ProjectTo<T>(_config).ToListAsync();
    }

    public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>>? filter = null, Expression<Func<TEntity, object>>? includeEntities = null, bool disableChangeTracker = true)
    {
        if (filter == null)
        {
            throw new ArgumentNullException(nameof(filter));
        }
        return InitQuery(filter, includeEntities, disableChangeTracker);
    }

    public IQueryable<TEntity> InitQuery(Expression<Func<TEntity, bool>>? filter = null, Expression<Func<TEntity, object>>? includeEntities = null, bool disableChangeTracker = true)
    {
        IQueryable<TEntity> query = _dbSet.AsQueryable();
        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (includeEntities != null)
        {
            query = query.Include(includeEntities);
        }

        if (disableChangeTracker)
        {
            query = query.AsNoTracking();
        }
        return query;
    }
}
