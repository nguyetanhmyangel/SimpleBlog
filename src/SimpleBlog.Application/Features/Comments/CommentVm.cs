namespace Application.Features.Comments
{
    public class CommentVm
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int KnowledgeId { get; set; }

        public string KnowledgeTitle { get; set; }

        public string KnowledgeSeoAlias { get; set; }

        public string OwnerUserId { get; set; }

        public string OwnerName { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public int? ReplyId { get; set; }

        //public PaginatedResult<CommentVm> Children { get; set; } = new PaginatedResult<CommentVm>();
    }
}