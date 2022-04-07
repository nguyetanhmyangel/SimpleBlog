using SimpleBlog.Application.Requests.Mail;

namespace SimpleBlog.Application.Interfaces.Services
{
    public interface ISmtpMailService
    {
        Task SendAsync(MailRequest request);
    }
}