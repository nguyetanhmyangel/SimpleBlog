using SimpleBlog.Application.Interfaces.Common;
using SimpleBlog.Application.Requests.Identity;
using SimpleBlog.Application.Responses.Identity;
using SimpleBlog.Share.Wrapper;

namespace SimpleBlog.Application.Interfaces.Services.Identity
{
    public interface ITokenService : IService
    {
        Task<Result<TokenResponse>> LoginAsync(TokenRequest model);

        Task<Result<TokenResponse>> GetRefreshTokenAsync(RefreshTokenRequest model);
    }
}