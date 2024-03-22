namespace PartyKid;

public interface ICommandRepository<TEntity> where TEntity : class
{
    void Add(params TEntity[] entities);

    void Update(params TEntity[] entities);

    void Delete(params TEntity[] entities);

}
