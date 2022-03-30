using System;

namespace SimpleBlog.Application.Features.Votes
{
    public class VoteResponse
    {
        public int KnowledgeBaseId { get; set; }
        public string UserId { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}