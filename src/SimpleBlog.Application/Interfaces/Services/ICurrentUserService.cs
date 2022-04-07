using SimpleBlog.Application.Interfaces.Common;

namespace SimpleBlog.Application.Interfaces.Services
{
    public interface ICurrentUserService : IService
    {
        string UserId { get; }
    }
}