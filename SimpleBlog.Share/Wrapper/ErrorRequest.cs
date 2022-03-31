namespace SimpleBlog.Share.Wrapper
{
    public class ErrorRequest
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}