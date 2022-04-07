using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using SimpleBlog.Application.Configurations;
using SimpleBlog.Application.Interfaces.Services;
using SimpleBlog.Application.Requests.Mail;

namespace SimpleBlog.Infrastructure.Share.Services
{
    public class SmtpMailService : ISmtpMailService
    {
        private readonly MailConfiguration _config;
        private readonly ILogger<SmtpMailService> _logger;

        public SmtpMailService(IOptions<MailConfiguration> config, ILogger<SmtpMailService> logger)
        {
            _config = config.Value;
            _logger = logger;
        }

        public async Task SendAsync(MailRequest request)
        {
            try
            {
                var email = new MimeMessage
                {
                    Sender = new MailboxAddress(_config.DisplayName, request.From ?? _config.From),
                    Subject = request.Subject,
                    Body = new BodyBuilder
                    {
                        HtmlBody = request.Body
                    }.ToMessageBody()
                };
                email.To.Add(MailboxAddress.Parse(request.To));
                using var smtp = new SmtpClient();
                await smtp.ConnectAsync(_config.Host, _config.Port, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(_config.UserName, _config.Password);
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
        }
    }
}