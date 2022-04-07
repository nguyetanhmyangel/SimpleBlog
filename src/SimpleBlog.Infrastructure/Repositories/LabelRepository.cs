using SimpleBlog.Application.Interfaces.Repositories;
using SimpleBlog.Domain.Entities.Catalog;

namespace SimpleBlog.Infrastructure.Repositories
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