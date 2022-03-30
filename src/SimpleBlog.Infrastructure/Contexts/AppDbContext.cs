using Application.Interfaces.Services;
using Infrastructure.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SimpleBlog.Application.Interfaces.Services;
using SimpleBlog.Domain.Abstractions;
using SimpleBlog.Domain.Entities;

namespace SimpleBlog.Infrastructure.Contexts
{
    public class AppDbContext : AuditContext
    {
        private readonly IDateTimeService _dateTime;
        private readonly IAuthenticatedUserService _authenticatedUser;

        public AppDbContext(DbContextOptions options, IDateTimeService dateTime, IAuthenticatedUserService authenticatedUser)
            : base(options)
        {
            _dateTime = dateTime;
            _authenticatedUser = authenticatedUser;
        }

        //public IDbConnection Connection => Database.GetDbConnection();

        //public bool HasChanges => ChangeTracker.HasChanges();

        public DbSet<AppCommand> AppCommands { get; set; }
        public DbSet<AppCommandFunction> AppCommandFunctions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Function> Functions { get; set; }
        public DbSet<Article> Article { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<LabelArticle> LabelArticles { get; set; }
        public DbSet<AppPermission> AppPermissions { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Attachment> Attachments { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var modified = ChangeTracker.Entries()
                .Where(e => e.State is EntityState.Modified or EntityState.Added);
            foreach (var item in modified)
            {
                if (item.Entity is IAuditEntity changedOrAddedItem)
                {
                    if (item.State == EntityState.Added)
                    {
                        changedOrAddedItem.CreatedOn = _dateTime.NowUtc;
                        changedOrAddedItem.CreatedBy = _authenticatedUser.UserId;
                    }
                    else
                    {
                        changedOrAddedItem.UpdateOn = _dateTime.NowUtc;
                        changedOrAddedItem.UpdateBy = _authenticatedUser.UserId;
                    }
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        //public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        //{
        //    foreach (var entry in ChangeTracker.Entries<AuditableEntity>().ToList())
        //    {
        //        switch (entry.State)
        //        {
        //            case EntityState.Added:
        //                entry.Entity.CreatedOn = _dateTime.NowUtc;
        //                entry.Entity.CreatedBy = _authenticatedUser.UserId;
        //                break;

        //            case EntityState.Modified:
        //                entry.Entity.LastModifiedOn = _dateTime.NowUtc;
        //                entry.Entity.LastModifiedBy = _authenticatedUser.UserId;
        //                break;
        //        }
        //    }
        //    if (_authenticatedUser.UserId == null)
        //    {
        //        return await base.SaveChangesAsync(cancellationToken);
        //    }
        //    else
        //    {
        //        return await base.SaveChangesAsync(_authenticatedUser.UserId);
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var property in builder.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(18,2)");
            }
            base.OnModelCreating(builder);

            //builder.HasDefaultSchema("Identity");
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "Users", "Identity");
            });

            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Roles", "Identity");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles", "Identity");
            });

            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims", "Identity");
            });

            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins", "Identity");
            });

            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims", "Identity");
            });

            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens", "Identity");
            });

            builder.HasSequence("ArticleSequence");

            builder.Entity<AppCommandFunction>()
                .HasIndex(p => new { p.AppCommandId, p.FunctionId })
                .IsUnique(true);

            builder.Entity<AppPermission>()
                .HasIndex(p => new { p.AppCommandId, p.FunctionId, p.RoleId })
                .IsUnique(true);

            builder.Entity<LabelArticle>()
                .HasIndex(p => new { p.LabelId, p.ArticleId })
                .IsUnique(true);
        }
    }
}