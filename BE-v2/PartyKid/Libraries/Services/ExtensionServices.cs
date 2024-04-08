using System.Linq.Expressions;

namespace PartyKid;

public class ExtensionServices<TEntity> : IExtensionServices<TEntity> where TEntity : class
{
    protected readonly IQueryRepository<TEntity> _queryRepository;
    protected readonly ICommandRepository<TEntity> _commandRepository;
    protected readonly IUnitOfWork _unitOfWork;

    public ExtensionServices(IQueryRepository<TEntity> queryRepository, ICommandRepository<TEntity> commandRepository, IUnitOfWork unitOfWork)
    {
        _queryRepository = queryRepository;
        _commandRepository = commandRepository;
        _unitOfWork = unitOfWork;
    }

    public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>>? filter = null, Expression<Func<TEntity, object>>? includeEntities = null, bool disableChangeTracker = true)
    {
        return _queryRepository.InitQuery(filter, includeEntities, disableChangeTracker);
    }

    public async Task<string> DeleteAsync(TEntity entity)
    {
        if (entity == null)
        {
            throw new DomainException(Constants.Transactions.Messages.NotFound);
        }

        try
        {
            _commandRepository.Delete(entities: entity);
            await _unitOfWork.SaveChangesAsync();
            return Constants.Transactions.Messages.DeleteComplete;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
