using BlazorHero.CleanArchitecture.Application.Interfaces.Chat;
using SimpleBlog.Application.Models.Chat;
using SimpleBlog.Application.Responses.Identity;
using SimpleBlog.Share.Wrapper;

namespace SimpleBlog.Application.Interfaces.Services
{
    public interface IChatService
    {
        Task<Result<IEnumerable<ChatUserResponse>>> GetChatUsersAsync(string userId);

        Task<IResult> SaveMessageAsync(ChatHistory<IChatUser> message);

        Task<Result<IEnumerable<ChatHistoryResponse>>> GetChatHistoryAsync(string userId, string contactId);
    }
}