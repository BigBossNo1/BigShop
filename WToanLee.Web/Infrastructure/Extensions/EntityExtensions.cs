using Web.Models.Models;
using WToanLee.Web.Models;

namespace WToanLee.Web.Infrastructure.Extensions
{
    public static class EntityExtensions
    {
        /*
         khi gọi đến bảng Postcategory mà thêm phương thức UpdatePostcategory thì dữ liệu bên PostcategoryViewModel
         sẽ tự động cập nhật sang bảng Postcategorie
         */
        // Đây là các hàm dùng để update dữ liệu từ 2 bảng với nhau

        // uapdate postcategory
        public static void UpdatePostCategory(this PostCategorie postCategorie, PostcategoryViewModel postCategoryViewModel)
        {
            postCategorie.ID = postCategoryViewModel.ID;
            postCategorie.Name = postCategoryViewModel.Name;
            postCategorie.Alias = postCategoryViewModel.Alias;
            postCategorie.Description = postCategoryViewModel.Description;
            postCategorie.ParentID = postCategoryViewModel.ParentID;
            postCategorie.Image = postCategoryViewModel.Image;
            postCategorie.DisplayOrder = postCategoryViewModel.DisplayOrder;
            postCategorie.HomeFlag = postCategoryViewModel.HomeFlag;
            // Follow Interface
            postCategorie.CreateDate = postCategoryViewModel.CreateDate;
            postCategorie.CreateBy = postCategoryViewModel.CreateBy;
            postCategorie.UpdateDate = postCategoryViewModel.UpdateDate;
            postCategorie.UpdateBy = postCategoryViewModel.UpdateBy;
            postCategorie.MetaKeyWord = postCategoryViewModel.MetaKeyWord;
            postCategorie.MetaDesciption = postCategoryViewModel.MetaDesciption;
            postCategorie.Status = postCategoryViewModel.Status;
        }

        //update post
        public static void UpdatePost(this Post post, PostViewModel postViewModel)
        {
            post.ID = postViewModel.ID;
            post.Name = postViewModel.Name;
            post.Alias = postViewModel.Alias;
            post.CategoryID = postViewModel.CategoryID;
            post.Image = postViewModel.Image;
            post.Description = postViewModel.Description;
            post.Content = postViewModel.Content;
            post.HomeFlag = postViewModel.HomeFlag;
            post.HotFlag = postViewModel.HotFlag;
            post.ViewCount = postViewModel.ViewCount;
            // Follow Interface
            post.CreateDate = postViewModel.CreateDate;
            post.CreateBy = postViewModel.CreateBy;
            post.UpdateDate = postViewModel.UpdateDate;
            post.UpdateBy = postViewModel.UpdateBy;
            post.MetaKeyWord = postViewModel.MetaKeyWord;
            post.MetaDesciption = postViewModel.MetaDesciption;
            post.Status = postViewModel.Status;
        }

        // update product cateory
        public static void UpdateProductCategory(this ProductCategorye productCategorie, ProductCategoryViewModel productCategoryViewModel)
        {
            productCategorie.ID = productCategoryViewModel.ID;
            productCategorie.Name = productCategoryViewModel.Name;
            productCategorie.Alias = productCategoryViewModel.Alias;
            productCategorie.Description = productCategoryViewModel.Description;
            productCategorie.ParentID = productCategoryViewModel.ParentID;
            productCategorie.Image = productCategoryViewModel.Image;
            productCategorie.DisplayOrder = productCategoryViewModel.DisplayOrder;
            productCategorie.HomeFlag = productCategoryViewModel.HomeFlag;
            // Follow Interface
            productCategorie.CreateDate = productCategoryViewModel.CreateDate;
            productCategorie.CreateBy = productCategoryViewModel.CreateBy;
            productCategorie.UpdateDate = productCategoryViewModel.UpdateDate;
            productCategorie.UpdateBy = productCategoryViewModel.UpdateBy;
            productCategorie.MetaKeyWord = productCategoryViewModel.MetaKeyWord;
            productCategorie.MetaDesciption = productCategoryViewModel.MetaDesciption;
            productCategorie.Status = productCategoryViewModel.Status;
        }

        // update product
        public static void UpdateProduct(this Product product, ProductViewModel productViewModel)
        {
            product.ID = productViewModel.ID;
            product.Name = productViewModel.Name;
            product.Alias = productViewModel.Alias;
            product.CategoryID = productViewModel.CategoryID;
            product.Image = productViewModel.Image;
            product.MoreImage = productViewModel.MoreImage;
            product.Price = productViewModel.Price;
            product.PromotionPrice = productViewModel.PromotionPrice;
            product.Warranty = productViewModel.Warranty;
            product.Description = productViewModel.Description;
            product.Content = productViewModel.Content;
            // Follow Interface
            product.HomeFlag = productViewModel.HomeFlag;
            product.HotFlag = productViewModel.HotFlag;
            product.ViewCount = productViewModel.ViewCount;
            product.CreateDate = productViewModel.CreateDate;
            product.CreateBy = productViewModel.CreateBy;
            product.Status = productViewModel.Status;
            product.MetaKeyWord = productViewModel.MetaKeyWord;
            product.MetaDesciption = productViewModel.MetaDesciption;
            product.Tags = productViewModel.Tags;
            product.Quantity = productViewModel.Quantity;
        }

        // update slide
        public static void UpdateSlide(this Slide slide, SlideViewModel slideViewModel)
        {
            slide.ID = slideViewModel.ID;
            slide.Name = slideViewModel.Name;
            slide.Descripts = slideViewModel.Descripts;
            slide.Image = slideViewModel.Image;
            slide.URL = slideViewModel.URL;
            slide.DisplayOrder = slideViewModel.DisplayOrder;
            slide.Status = slideViewModel.Status;
            slide.Content = slideViewModel.Content;
        }

        public static void updateTag(this Tag tag , TagViewModel tagViewModel)
        {
            tag.ID = tagViewModel.ID;
            tag.Name = tagViewModel.Name;
            tag.Type = tagViewModel.Type;
        }
    }
}