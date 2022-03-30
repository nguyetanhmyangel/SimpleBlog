
using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Infrastructure.Repositories
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