using SimpleBlog.Application.Interfaces.Repositories;
using SimpleBlog.Domain.Entities.Catalog;

namespace SimpleBlog.Infrastructure.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly IRepositoryAsync<Report, int> _repository;

        public ReportRepository(IRepositoryAsync<Report, int> repository)
        {
            _repository = repository;
        }
    }
}