namespace SimpleBlog.Application.Features.Comments
{
    public class CommentCreateRequest
    {
        public string? Content { get; set; }

        public int ArticleId { get; set; }

        public int? ReplyId { get; set; }

        public string? CaptchaCode { get; set; }
    }
}