using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Application.Interfaces.Contexts
{
    public interface IApplicationDbContext
    {
        IDbConnection Connection { get; }
        bool HasChanges { get; }

        //EntityEntry Entry(object entity);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        public DbSet<AppCommand> AppCommands { set; get; }
        public DbSet<AppCommandFunction> AppCommandFunctions { set; get; }
        public DbSet<Category> Categories { set; get; }
        public DbSet<Comment> Comments { set; get; }
        public DbSet<Function> Functions { set; get; }
        public DbSet<Knowledge> Knowledge { set; get; }
        public DbSet<Label> Labels { set; get; }
        public DbSet<LabelKnowledge> LabelInKnowledge { set; get; }
        public DbSet<AppPermission> AppPermissions { set; get; }
        public DbSet<Report> Reports { set; get; }
        public DbSet<Vote> Votes { set; get; }
        public DbSet<Attachment> Attachments { get; set; }
    }
}