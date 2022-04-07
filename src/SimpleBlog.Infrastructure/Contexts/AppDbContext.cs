using System.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SimpleBlog.Application.Interfaces.Contexts;
using SimpleBlog.Application.Interfaces.Services;
using SimpleBlog.Domain.Contracts;
using SimpleBlog.Domain.Entities.Catalog;
using SimpleBlog.Infrastructure.Models.Audit;
using SimpleBlog.Infrastructure.Models.Identity;

namespace SimpleBlog.Infrastructure.Contexts
{
    public class AppDbContext : AuditContext, IAppDbContext
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTimeService _dateTimeService;

        public AppDbContext(DbContextOptions<AppDbContext> options, ICurrentUserService currentUserService, 
            IDateTimeService dateTimeService)
            : base(options)
        {
            _currentUserService = currentUserService;
            _dateTimeService = dateTimeService;
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<LabelArticle> LabelArticles { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Vote> Votes { get; set; }

        public IDbConnection Connection { get; }
        public bool HasChanges { get; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            foreach (var entry in ChangeTracker.Entries<IAuditEntity>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = _dateTimeService.NowUtc;
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedOn = _dateTimeService.NowUtc;
                        entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        break;
                }
            }
            if (_currentUserService.UserId == null)
            {
                return await base.SaveChangesAsync(cancellationToken);
            }
            else
            {
                return await base.SaveChangesAsync(_currentUserService.UserId, cancellationToken);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var property in builder.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(18,2)");
            }

            foreach (var property in builder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.Name is "LastModifiedBy" or "CreatedBy"))
            {
                property.SetColumnType("nvarchar(128)");
            }

            base.OnModelCreating(builder);

            builder.Entity<User>(entity =>
            {
                entity.ToTable(name: "Users", "Identity");
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            builder.Entity<Role>(entity =>
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

            builder.Entity<RoleClaim>(entity =>
            {
                entity.ToTable(name: "RoleClaims", "Identity");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleClaims)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens", "Identity");
            });
        }
    }
}