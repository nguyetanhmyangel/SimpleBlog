using System;

namespace SimpleBlog.Application.Features.Comments
{
    public class CommentResponse
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int ArticleId { get; set; }

        public string ArticleTitle { get; set; }

        public string ArticleSeoAlias { get; set; }

        public string OwnerUserId { get; set; }

        public string OwnerName { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public int? ReplyId { get; set; }

        //public PaginatedResult<CommentVm> Children { get; set; } = new PaginatedResult<CommentVm>();
    }
}