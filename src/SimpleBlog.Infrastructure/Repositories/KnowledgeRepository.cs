using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class KnowledgeRepository : IKnowledgeRepository
    {
        private readonly IRepositoryAsync<Knowledge, int> _repository;

        public KnowledgeRepository(IRepositoryAsync<Knowledge, int> repository)
        {
            _repository = repository;
        }
    }
}