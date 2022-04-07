using SimpleBlog.Application.Interfaces.Repositories;
using SimpleBlog.Domain.Entities.Catalog;

namespace SimpleBlog.Infrastructure.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly IRepositoryAsync<Comment, int> _repository;

        public CommentRepository(IRepositoryAsync<Comment, int> repository)
        {
            _repository = repository;
        }
    }
}