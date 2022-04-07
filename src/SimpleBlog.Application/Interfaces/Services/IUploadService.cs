using SimpleBlog.Application.Requests;

namespace SimpleBlog.Application.Interfaces.Services
{
    public interface IUploadService
    {
        string UploadAsync(UploadRequest request);
    }
}