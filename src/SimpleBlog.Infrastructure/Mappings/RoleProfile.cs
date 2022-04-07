using AutoMapper;
using SimpleBlog.Application.Responses.Identity;
using SimpleBlog.Infrastructure.Models.Identity;

namespace SimpleBlog.Infrastructure.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleResponse, Role>().ReverseMap();
        }
    }
}