using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleBlog.Application.Interfaces;
using SimpleBlog.Application.Interfaces.Contexts;
using SimpleBlog.Application.Interfaces.Repositories;
using SimpleBlog.Infrastructure.Contexts;
using SimpleBlog.Infrastructure.Repositories;

namespace SimpleBlog.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPersistenceContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IAppDbContext, AppDbContext>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
            services.AddTransient<IAppCommandFunctionRepository, AppCommandFunctionRepository>();
            services.AddTransient<IAppCommandRepository, AppCommandRepository>();
            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<IAttachmentRepository, AttachmentRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<IFunctionRepository, FunctionRepository>();
            services.AddTransient<ILabelArticleRepository, LabelArticleRepository>();
            services.AddTransient<ILabelRepository, LabelRepository>();
            services.AddTransient<IReportRepository, ReportRepository>();
            services.AddTransient<IVoteRepository, VoteRepository>();
            //services.AddTransient<ILogRepository, LogRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}