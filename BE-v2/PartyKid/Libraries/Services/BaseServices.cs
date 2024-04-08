using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace PartyKid;

public class BaseServices<TEntity> : IBaseServices<TEntity> where TEntity : BaseEntity<int>
{
    protected readonly IQueryRepository<TEntity> _queryRepository;
    protected readonly ICommandRepository<TEntity> _commandRepository;
    protected readonly IUnitOfWork _unitOfWork;

    public BaseServices(IQueryRepository<TEntity> queryRepository, ICommandRepository<TEntity> commandRepository, IUnitOfWork unitOfWork)
    {
        _queryRepository = queryRepository;
        _commandRepository = commandRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IList<TResponse>> GetAllAsync<TResponse>(Expression<Func<TEntity, bool>>? filter = null, Expression<Func<TEntity, object>>? includeEntities = null, bool disableChangeTracker = true)
                => await _queryRepository.GetAllAsync<TResponse>(filter, includeEntities, disableChangeTracker);

    public IList<TEntity> GetAll() => _queryRepository.InitQuery().ToList();

    public async Task<TEntity> Find(int id) => await _queryRepository.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task<IList<TResponse>> Search<TResponse>(Expression<Func<TEntity, bool>>? filter = null, Expression<Func<TEntity, object>>? includeEntities = null, bool disableChangeTracker = true)
    {
        return await _queryRepository.GetAllAsync<TResponse>(filter: filter, includeEntities: includeEntities, disableChangeTracker: disableChangeTracker);
    }

    public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>>? filter = null, Expression<Func<TEntity, object>>? includeEntities = null, bool disableChangeTracker = true)
    {
        return _queryRepository.InitQuery(filter, includeEntities, disableChangeTracker);
    }
    public async Task<string> Create(TEntity entity)
    {
        try
        {
            _commandRepository.Add(entities: entity);
            await _unitOfWork.SaveChangesAsync();
            return Constants.Transactions.Messages.AddComplete;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }

    public async Task<TEntity> Update(TEntity entity)
    {
        try
        {
            _commandRepository.Update(entities: entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<string> Delete(int id)
    {
        var entity = _queryRepository.Find(x => x.Id == id).FirstOrDefault();
        if (entity == null)
        {
            throw new DomainException(Constants.Transactions.Messages.NotFound);
        }

        try
        {
            entity.IsDeleted = true;
            _commandRepository.Update(entities: entity);
            await _unitOfWork.SaveChangesAsync();
            return Constants.Transactions.Messages.DeleteComplete;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
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
