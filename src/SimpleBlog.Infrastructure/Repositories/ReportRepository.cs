using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Infrastructure.Repositories
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