using Application.Interfaces.Repositories;
using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Repositories
{
    [Table("LabelKnowledge")]
    public class LabelKnowledgeRepository : ILabelKnowledgeRepository
    {
        private readonly IRepositoryAsync<LabelKnowledge, int> _repository;

        public LabelKnowledgeRepository(IRepositoryAsync<LabelKnowledge, int> repository)
        {
            _repository = repository;
        }
    }
}