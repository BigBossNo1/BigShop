using AutoMapper;
using Web.Models.Models;
using WToanLee.Web.Models;

namespace WToanLee.Web.Mappings
{
    public class AutoMapperConfiguration 
    {
        public static void Configure()
        {
            Mapper.CreateMap<PostCategorie, PostcategoryViewModel>();
            Mapper.CreateMap<Tag, TagViewModel>();
            Mapper.CreateMap<PostTag, PostTagViewModel>();
            Mapper.CreateMap<ProductCategorye, ProductCategoryViewModel>();
            Mapper.CreateMap<Product, ProductViewModel>();
            Mapper.CreateMap<ProductTag, ProductTagViewModel>();
            Mapper.CreateMap<Post, PostViewModel>();
            Mapper.CreateMap<Slide, SlideViewModel>(); 
        }

    }
}