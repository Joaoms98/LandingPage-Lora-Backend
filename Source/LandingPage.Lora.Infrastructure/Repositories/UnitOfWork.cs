using LandingPage.Lora.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LandingPage.Lora.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly LoraDbContext _dbContext = null;
    private bool disposed = false;
    private readonly QueryTrackingBehavior _defaultQueryTrackBehavior;

    // public UnitOfWork(LoraDbContext dbContext)
    // {
    //     _dbContext = dbContext;
    //     _defaultQueryTrackBehavior = dbContext.ChangeTracker.QueryTrackingBehavior;
    // }

    // private ILogRepository _logRepository;

    // public ILogRepository LogRepository
    // {
    //     get { return _logRepository = _logRepository ?? new LogRepository(_dbContext); }
    // }

    public IUnitOfWork SetReadOnlyMode()
    {
        _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTrackingWithIdentityResolution;
        return this;
    }

    public IUnitOfWork RestoreDefaultMode()
    {
        _dbContext.ChangeTracker.QueryTrackingBehavior = _defaultQueryTrackBehavior;
        return this;
    }

    public void Commit()
    {
        _dbContext.SaveChanges();
    }

    public async Task CommitAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    public void Rollback()
    {
        _dbContext.Dispose();
    }

    public async Task RollbackAsync()
    {
        await _dbContext.DisposeAsync();
    }

    public virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}