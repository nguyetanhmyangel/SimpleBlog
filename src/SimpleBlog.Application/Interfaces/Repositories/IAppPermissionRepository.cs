using SimpleBlog.Domain.Entities;

namespace SimpleBlog.Application.Interfaces.Repositories
{
    public interface IAppPermissionRepository
    {
        IQueryable<AppPermission> AppPermissions { get; }

        Task<List<AppPermission>> GetListAsync();

        Task<AppPermission> GetByIdAsync(int appPermissionId);

        Task<List<AppPermission>> GetCachedListAsync();

        Task<AppPermission?> GetCachedByIdAsync(int appPermissionId);

        Task<int> AddAsync(AppPermission appPermission);

        Task UpdateAsync(AppPermission appPermission);

        Task DeleteAsync(AppPermission appPermission);
    }
}
