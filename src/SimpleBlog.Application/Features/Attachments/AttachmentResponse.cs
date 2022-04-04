using System;

namespace SimpleBlog.Application.Features.Attachments
{
    public class AttachmentResponse
    {
        public int Id { get; set; }
        public string? FileName { get; set; }
                     
        public string? FilePath { get; set; }
                     
        public string? FileType { get; set; }

        public long FileSize { get; set; }

        public int ArticleId { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}