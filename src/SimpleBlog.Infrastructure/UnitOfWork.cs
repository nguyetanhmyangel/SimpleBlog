using System.Collections;
using SimpleBlog.Application.Interfaces;
using SimpleBlog.Application.Interfaces.Services;
using SimpleBlog.Infrastructure.Contexts;

namespace SimpleBlog.Infrastructure
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly AppDbContext _dbContext;
        private bool _disposed;

        public UnitOfWork(AppDbContext dbContext, IAuthenticatedUserService authenticatedUserService)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _authenticatedUserService = authenticatedUserService;
        }

        public async Task<int> Commit(CancellationToken cancellationToken)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public Task Rollback()
        {
            _dbContext.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    //dispose managed resources
                    _dbContext.Dispose();
                }
            }
            //dispose unmanaged resources
            _disposed = true;
        }

    }
}
