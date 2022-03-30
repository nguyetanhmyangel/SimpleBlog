using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Infrastructure.Repositories
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