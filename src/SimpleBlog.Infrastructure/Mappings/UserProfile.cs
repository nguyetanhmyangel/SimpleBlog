using AutoMapper;
using SimpleBlog.Application.Responses.Identity;
using SimpleBlog.Infrastructure.Models.Identity;

namespace SimpleBlog.Infrastructure.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserResponse, User>().ReverseMap();
            //CreateMap<ChatUserResponse, User>().ReverseMap()
            //    .ForMember(dest => dest.EmailAddress, source => source.MapFrom(source => source.Email)); //Specific Mapping
        }
    }
}