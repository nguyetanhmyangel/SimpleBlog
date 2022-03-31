using SimpleBlog.Domain.Entities;

namespace SimpleBlog.Application.Interfaces.Repositories
{
    public interface ILabelRepository
    {
        IQueryable<Label> Labels { get; }

        Task<List<Label>> GetListAsync();

        Task<Label> GetByIdAsync(int labelId);

        Task<List<Label>> GetCachedListAsync();

        Task<Label> GetCachedByIdAsync(int labelId);

        Task<int> AddAsync(Label label);

        Task UpdateAsync(Label label);

        Task DeleteAsync(Label label);
    }
}
