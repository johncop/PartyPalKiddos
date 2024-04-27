using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace PartyKid;

public class CommandRepository<TEntity> : ICommandRepository<TEntity> where TEntity : class
{
    protected readonly PartyKidDbContext _dbContext;
    protected readonly DbSet<TEntity> _dbSet;

    public CommandRepository(PartyKidDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<TEntity>();
    }

    public void Add(params TEntity[] entities)
    {
        PerformDbOperation(_dbSet.Add, entities);
    }

    public void Update(params TEntity[] entities)
    {
        PerformDbOperation(_dbSet.Update, entities);
    }

    public void Delete(params TEntity[] entities)
    {
        PerformDbOperation(_dbSet.Remove, entities);
    }

    private void PerformDbOperation(Func<TEntity, EntityEntry<TEntity>> dbOperation, params TEntity[] entities)
    {
        if (dbOperation == null)
        {
            throw new ArgumentNullException(nameof(dbOperation));
        }

        if (entities == null || entities.Any(x => x == null))
        {
            throw new ArgumentException(nameof(entities));
        }

        foreach (TEntity entity in entities)
        {
            dbOperation(entity);
        }
    }
}
