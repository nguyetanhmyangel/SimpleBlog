using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace SimpleBlog.Application.Mapping
{
    public class ResponseToEntityMappingProfile : Profile
    {
        //CreateMap<ProductCategoryViewModel, ProductCategory>()
        //.ConstructUsing(c => new ProductCategory(c.Name, c.Description, c.ParentId, c.HomeOrder, c.Image, c.HomeFlag,
        //    c.SortOrder, c.Status, c.SeoPageTitle, c.SeoAlias, c.SeoKeywords, c.SeoDescription));

        //CreateMap<ProductViewModel, Product>()
        //.ConstructUsing(c => new Product(c.Name, c.CategoryId, c.Image, c.Price, c.OriginalPrice,
        //    c.PromotionPrice, c.Description, c.Content, c.HomeFlag, c.HotFlag, c.Tags, c.Unit, c.Status,
        //    c.SeoPageTitle, c.SeoAlias, c.SeoKeywords, c.SeoDescription));
    }
}
