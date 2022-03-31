using SimpleBlog.Domain.Entities;

namespace SimpleBlog.Application.Interfaces.Repositories
{
    public interface IReportRepository
    {
        IQueryable<Report> Reports { get; }

        Task<List<Report>> GetListAsync();

        Task<Report> GetByIdAsync(int reportId);

        Task<List<Report>> GetCachedListAsync();

        Task<Report> GetCachedByIdAsync(int reportId);

        Task<int> AddAsync(Report report);

        Task UpdateAsync(Report report);

        Task DeleteAsync(Report report);
    }
}
