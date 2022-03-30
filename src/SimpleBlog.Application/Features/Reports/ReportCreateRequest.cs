namespace SimpleBlog.Application.Features.Reports
{
    public class ReportCreateRequest
    {
        public int? ArticleId { get; set; }

        public string Content { get; set; }

        public string CaptchaCode { get; set; }
    }
}