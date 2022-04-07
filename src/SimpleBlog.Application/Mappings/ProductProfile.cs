using AutoMapper;
using SimpleBlog.Application.Features.Articles.Commands.AddEdit;
using SimpleBlog.Domain.Entities.Catalog;

namespace SimpleBlog.Application.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<AddEditProductCommand, Product>().ReverseMap();
        }
    }
}