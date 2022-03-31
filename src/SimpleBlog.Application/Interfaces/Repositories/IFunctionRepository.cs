using SimpleBlog.Domain.Entities;

namespace SimpleBlog.Application.Interfaces.Repositories
{
    public interface IFunctionRepository
    {
        IQueryable<Function> Functions { get; }

        Task<List<Function>> GetListAsync();

        Task<Function> GetByIdAsync(int functionId);

        Task<List<Function>> GetCachedListAsync();

        Task<Function> GetCachedByIdAsync(int functionId);

        Task<int> AddAsync(Function function);

        Task UpdateAsync(Function function);

        Task DeleteAsync(Function function);
    }
}
