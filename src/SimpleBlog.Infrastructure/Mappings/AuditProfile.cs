using AutoMapper;
using SimpleBlog.Application.Responses.Audit;
using SimpleBlog.Infrastructure.Models.Audit;

namespace SimpleBlog.Infrastructure.Mappings
{
    public class AuditProfile : Profile
    {
        public AuditProfile()
        {
            CreateMap<AuditResponse, Audit>().ReverseMap();
        }
    }
}