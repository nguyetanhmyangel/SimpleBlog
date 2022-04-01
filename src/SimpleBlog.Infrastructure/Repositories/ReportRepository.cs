using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using SimpleBlog.Application.Interfaces;
using SimpleBlog.Application.Interfaces.Repositories;
using SimpleBlog.Domain.Entities;
using SimpleBlog.Infrastructure.CacheKeys;
using SimpleBlog.Infrastructure.Share.Caching;
using SimpleBlog.Infrastructure.Share.ThrowR;

namespace SimpleBlog.Infrastructure.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly IRepositoryAsync<Report> _repository;
        private readonly IDistributedCache _distributedCache;

        public ReportRepository(IDistributedCache distributedCache, IRepositoryAsync<Report> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }

        public IQueryable<Report> Reports => _repository.Entities;

        public async Task DeleteAsync(Report report)
        {
            await _repository.DeleteAsync(report);
            await _distributedCache.RemoveAsync(ReportCacheKey.ListKey);
            await _distributedCache.RemoveAsync(ReportCacheKey.GetKey(report.Id));
        }

        public async Task<Report> GetByIdAsync(int ReportId)
        {
            return await _repository.Entities.Where(p => p.Id == ReportId).FirstOrDefaultAsync() ?? throw new InvalidOperationException();
        }

        public async Task<Report> GetCachedByIdAsync(int reportId)
        {
            var cacheKey = ReportCacheKey.GetKey(reportId);
            var list = await _distributedCache.GetAsync<Report>(cacheKey);
            if (list == null)
            {
                list = await _repository.Entities.Where(p => p.Id == reportId).FirstOrDefaultAsync();
                Throw.Exception.IfNull(list, "Report", "No item Found");
                await _distributedCache.SetAsync(cacheKey, list);

            }
            return list;
        }

        public async Task<List<Report>> GetCachedListAsync()
        {
            var cacheKey = ReportCacheKey.ListKey;
            var list = await _distributedCache.GetAsync<List<Report>>(cacheKey);
            if (list == null)
            {
                list = await _repository.Entities.ToListAsync();
                await _distributedCache.SetAsync(cacheKey, list);
            }
            return list;
        }


        public async Task<List<Report>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<int> AddAsync(Report report)
        {
            await _repository.AddAsync(report);
            await _distributedCache.RemoveAsync(ReportCacheKey.ListKey);
            return report.Id;
        }

        public async Task UpdateAsync(Report report)
        {
            await _repository.UpdateAsync(report);
            await _distributedCache.RemoveAsync(ReportCacheKey.ListKey);
            await _distributedCache.RemoveAsync(ReportCacheKey.GetKey(report.Id));
        }
    }
}