using System.Linq.Expressions;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace PartyKid;

public class BaseServices<TEntity> : IBaseServices<TEntity> where TEntity : BaseEntity
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
        return _queryRepository.InitQuery();
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
            throw new Exception(Constants.Transactions.Messages.NotFound);
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
}
