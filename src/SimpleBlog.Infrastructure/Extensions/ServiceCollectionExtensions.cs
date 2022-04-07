using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using SimpleBlog.Application.Interfaces.Repositories;
using SimpleBlog.Application.Interfaces.Serialization.Serializers;
using SimpleBlog.Application.Serialization.JsonConverters;
using SimpleBlog.Application.Serialization.Options;
using SimpleBlog.Application.Serialization.Serializers;
using SimpleBlog.Infrastructure.Repositories;
//using SimpleBlog.Infrastructure.Services.Storage;
//using SimpleBlog.Infrastructure.Services.Storage.Provider;
//using SimpleBlog.Application.Interfaces.Services.Storage;
//using SimpleBlog.Application.Interfaces.Services.Storage.Provider;

namespace SimpleBlog.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructureMappings(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddTransient(typeof(IRepositoryAsync<,>), typeof(RepositoryAsync<,>))
                .AddTransient<IArticleRepository, ArticleRepository>()
                .AddTransient<IAttachmentRepository, AttachmentRepository>()
                .AddTransient<ICategoryRepository, CategoryRepository>()
                .AddTransient<ICommentRepository, CommentRepository>()
                .AddTransient<ILabelArticleRepository, LabelArticleRepository>()
                .AddTransient<ILabelRepository, LabelRepository>()
                .AddTransient<IMenuRepository, MenuRepository>()
                .AddTransient<IReportRepository, ReportRepository>()
                .AddTransient<IVoteRepository, VoteRepository>()
                .AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
        }

        public static IServiceCollection AddExtendedAttributesUnitOfWork(this IServiceCollection services)
        {
            return services
                .AddTransient(typeof(IExtendedAttributeUnitOfWork<,,>), typeof(ExtendedAttributeUnitOfWork<,,>));
        }

        public static IServiceCollection AddServerStorage(this IServiceCollection services)
            => AddServerStorage(services, null);

        public static IServiceCollection AddServerStorage(this IServiceCollection services, Action<SystemTextJsonOptions>? configure)
        {
            return services
                .AddScoped<IJsonSerializer, SystemTextJsonSerializer>()
                //.AddScoped<IStorageProvider, ServerStorageProvider>()
                //.AddScoped<IServerStorageService, ServerStorageService>()
                //.AddScoped<ISyncServerStorageService, ServerStorageService>()
                .Configure<SystemTextJsonOptions>(configureOptions =>
                {
                    configure?.Invoke(configureOptions);
                    if (configureOptions.JsonSerializerOptions.Converters.All(c => c.GetType() != typeof(TimespanJsonConverter)))
                        configureOptions.JsonSerializerOptions.Converters.Add(new TimespanJsonConverter());
                });
        }
    }
}