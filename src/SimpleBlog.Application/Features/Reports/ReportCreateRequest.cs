namespace Application.Features.Reports
{
    public class ReportCreateRequest
    {
        public int? KnowledgeBaseId { get; set; }

        public string Content { get; set; }
        public string CaptchaCode { get; set; }
    }
}