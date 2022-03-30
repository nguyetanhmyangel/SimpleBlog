using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class LabelRepository : ILabelRepository
    {
        private readonly IRepositoryAsync<Label, int> _repository;

        public LabelRepository(IRepositoryAsync<Label, int> repository)
        {
            _repository = repository;
        }
    }
}