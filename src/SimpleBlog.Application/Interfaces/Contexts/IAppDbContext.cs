using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SimpleBlog.Domain.Entities.Catalog;

namespace SimpleBlog.Application.Interfaces.Contexts
{
    public interface IAppDbContext
    {
        IDbConnection Connection { get; }
        bool HasChanges { get; }

        EntityEntry Entry(object entity);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        public DbSet<Article> Articles { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<LabelArticle> LabelArticles { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Vote> Votes { get; set; }
    }
}