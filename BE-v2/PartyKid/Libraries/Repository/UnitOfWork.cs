﻿namespace PartyKid;

public class UnitOfWork : IUnitOfWork
{
    private readonly PartyKidDbContext _dbContext;
    public UnitOfWork(PartyKidDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
