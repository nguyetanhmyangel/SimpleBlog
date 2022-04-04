using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBlog.Domain.Entities;

namespace SimpleBlog.Application.Features.LabelArticles
{
    public class LabelArticleResponse
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }

        public int LabelId { get; set; }

        public virtual Article Article { get; set; }

        public virtual Label Label { get; set; }
    }
}
