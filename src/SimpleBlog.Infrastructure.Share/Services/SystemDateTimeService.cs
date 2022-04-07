using SimpleBlog.Application.Interfaces.Services;

namespace SimpleBlog.Infrastructure.Share.Services
{
    public class SystemDateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}