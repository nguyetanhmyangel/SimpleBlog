using SimpleBlog.Domain.Entities;

namespace SimpleBlog.Application.Interfaces.Repositories
{
    public interface IAppCommandRepository
    {
        IQueryable<AppCommand> AppCommands { get; }

        Task<List<AppCommand>> GetListAsync();

        Task<AppCommand> GetByIdAsync(int appCommandId);

        Task<List<AppCommand>> GetCachedListAsync();

        Task<AppCommand?> GetCachedByIdAsync(int appCommandId);

        Task<int> AddAsync(AppCommand appCommand);

        Task UpdateAsync(AppCommand appCommand);

        Task DeleteAsync(AppCommand appCommand);
    }
}
