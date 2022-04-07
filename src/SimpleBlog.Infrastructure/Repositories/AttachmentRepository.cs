using SimpleBlog.Application.Interfaces.Repositories;
using SimpleBlog.Domain.Entities.Catalog;

namespace SimpleBlog.Infrastructure.Repositories
{
    public class AttachmentRepository : IAttachmentRepository
    {
        private readonly IRepositoryAsync<Attachment, int> _repository;

        public AttachmentRepository(IRepositoryAsync<Attachment, int> repository)
        {
            _repository = repository;
        }
    }
}