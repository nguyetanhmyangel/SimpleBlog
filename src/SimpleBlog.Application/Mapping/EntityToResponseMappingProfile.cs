using AutoMapper;
using SimpleBlog.Application.Features.AppCommands;
using SimpleBlog.Application.Features.AppPermissions;
using SimpleBlog.Application.Features.Articles;
using SimpleBlog.Application.Features.Attachments;
using SimpleBlog.Application.Features.Categories;
using SimpleBlog.Application.Features.Functions;
using SimpleBlog.Application.Features.LabelArticles;
using SimpleBlog.Application.Features.Labels;
using SimpleBlog.Application.Features.Votes;
using SimpleBlog.Domain.Entities;
namespace SimpleBlog.Application.Mapping
{
    public class EntityToResponseMappingProfile : Profile
    {
        public EntityToResponseMappingProfile()
        {
            CreateMap<AppCommandFunction, CommandResponse>();
            CreateMap<AppCommand, CommandResponse>();
            CreateMap<AppPermission, PermissionResponse>();
            CreateMap<Function, FunctionResponse>();
            CreateMap<Article, ArticleResponse>();
            CreateMap<Attachment, AttachmentResponse>();
            CreateMap<Category, CategoryResponse>();
            CreateMap<Comment, CommandResponse>();
            CreateMap<Label, LabelResponse>();
            CreateMap<LabelArticle, LabelArticleResponse>();
            CreateMap<Vote, VoteResponse>();
        }
    }
}