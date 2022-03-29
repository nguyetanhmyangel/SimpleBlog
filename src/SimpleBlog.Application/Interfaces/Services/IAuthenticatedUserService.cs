namespace Application.Interfaces.Services
{
    public interface IAuthenticatedUserService
    {
        string UserId { get; }
        public string UserName { get; }
    }
}