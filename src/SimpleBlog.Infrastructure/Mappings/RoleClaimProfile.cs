using AutoMapper;
using SimpleBlog.Application.Requests.Identity;
using SimpleBlog.Application.Responses.Identity;
using SimpleBlog.Infrastructure.Models.Identity;

namespace SimpleBlog.Infrastructure.Mappings
{
    public class RoleClaimProfile : Profile
    {
        public RoleClaimProfile()
        {
            CreateMap<RoleClaimResponse, RoleClaim>()
                .ForMember(nameof(RoleClaim.ClaimType), opt => opt.MapFrom(c => c.Type))
                .ForMember(nameof(RoleClaim.ClaimValue), opt => opt.MapFrom(c => c.Value))
                .ReverseMap();

            CreateMap<RoleClaimRequest, RoleClaim>()
                .ForMember(nameof(RoleClaim.ClaimType), opt => opt.MapFrom(c => c.Type))
                .ForMember(nameof(RoleClaim.ClaimValue), opt => opt.MapFrom(c => c.Value))
                .ReverseMap();
        }
    }
}