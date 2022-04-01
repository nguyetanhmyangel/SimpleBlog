using SimpleBlog.Domain.Entities;

namespace SimpleBlog.Application.Interfaces.Repositories
{
    public interface IAppCommandFunctionRepository
    {
        IQueryable<AppCommandFunction> AppCommandFunctions { get; }

        Task<List<AppCommandFunction>> GetListAsync();

        Task<AppCommandFunction> GetByIdAsync(int commandFunctionId);

        Task<List<AppCommandFunction>> GetCachedListAsync();

        Task<AppCommandFunction> GetCachedByIdAsync(int commandFunctionId);

        Task<int> AddAsync(AppCommandFunction commandFunction);

        Task UpdateAsync(AppCommandFunction commandFunction);

        Task DeleteAsync(AppCommandFunction commandFunction);
    }
}
