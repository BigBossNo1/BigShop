using AutoMapper;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Web.Common;
using Web.Models.Models;
using Web.Service;
using WToanLee.Web.Infrastructure.Core;
using WToanLee.Web.Models;

namespace WToanLee.Web.Controllers
{
    public class ProductController : Controller
    {
        private ICommonService _commonService;
        private IProductService _iproductServive;
        private IProductCategoryService _productCategoryService;

        public ProductController(ICommonService commonService, IProductService productService, IProductCategoryService productCategoryService)
        {
            _commonService = commonService;
            _iproductServive = productService;
            _productCategoryService = productCategoryService;
        }

        // GET: Product
        public ActionResult Detail(int id)
        {
            var product = _iproductServive.GetById(id);
            var productViewModel = Mapper.Map<Product, ProductViewModel>(product);
            var relateProduct = _iproductServive.GetReatedProduct(id, 5);
            ViewBag.RelateProduc = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(relateProduct);
            //

            List<string> moreImage;
            if (!string.IsNullOrEmpty(productViewModel.MoreImage))
            {
                moreImage = new JavaScriptSerializer().Deserialize<List<string>>(productViewModel.MoreImage);
            }
            else
            {
                moreImage = new List<string>();
            }

            ViewBag.MoreImage = moreImage;
            ViewBag.Tag = Mapper.Map<IEnumerable<Tag>, IEnumerable<TagViewModel>>(_iproductServive.GetListTagProductID(id));
            //
            //List<string> moreImage = new JavaScriptSerializer().Deserialize<List<string>>(productViewModel.MoreImage);
            //ViewBag.MoreImage = moreImage;
            return View(productViewModel);
        }

        public ActionResult Category(int id, int page = 1, string sort = "")
        {
            // appSeting
            int pageSize = int.Parse(ConfigHelper.GetByKey("PageSize"));
            int totalRow = 0;
            var productModel = _iproductServive.GetListProductByCategoryIdPage(id, page, pageSize, sort, out totalRow);
            var productViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(productModel);
            // tinh tong so trang
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);
            // call doi tuong page
            var category = _productCategoryService.GetById(id);
            ViewBag.Category = Mapper.Map<ProductCategorye, ProductCategoryViewModel>(category);
            var paginationSet = new PagenationSet<ProductViewModel>()
            {
                Items = productViewModel,
                MaxPage = int.Parse(ConfigHelper.GetByKey("MaxPage")),
                Page = page,
                TotalCount = totalRow,
                TotalPage = totalPage
            };
            return View(paginationSet);
        }

        // TRANG TÌM KIẾM
        public ActionResult Search(string keyword , int page = 1, string sort = "")
        {
            // appSeting
            int pageSize = int.Parse(ConfigHelper.GetByKey("PageSize"));
            int totalRow = 0;
            var productModel = _iproductServive.Search(keyword, page, pageSize, sort, out totalRow);
            var productViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(productModel);
            // tinh tong so trang
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);
            // call doi tuong page
            ViewBag.keyword = keyword;
            var paginationSet = new PagenationSet<ProductViewModel>()
            {
                Items = productViewModel,
                MaxPage = int.Parse(ConfigHelper.GetByKey("MaxPage")),
                Page = page,
                TotalCount = totalRow,
                TotalPage = totalPage
            };
            return View(paginationSet);
        }
        public JsonResult GetListProductByName(string keyword)
        {
            var model = _iproductServive.GetListProductByName(keyword);
            return Json(new
            {
                data = model
            }, JsonRequestBehavior.AllowGet);
        }

        // TRANG LẤY RA DANH SÁCH TAG

        public ActionResult ListByTag(string tagid , int page = 1) {
            // appSeting
            int pageSize = int.Parse(ConfigHelper.GetByKey("PageSize"));
            int totalRow = 0;
            var productModel = _iproductServive.GetListProductByTag(tagid, page, pageSize, out totalRow);
            var productViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(productModel);
            // tinh tong so trang
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);
            // call doi tuong page
            ViewBag.Tag = Mapper.Map<Tag, TagViewModel>(_iproductServive.getTag(tagid));
            var paginationSet = new PagenationSet<ProductViewModel>()
            {
                Items = productViewModel,
                MaxPage = int.Parse(ConfigHelper.GetByKey("MaxPage")),
                Page = page,
                TotalCount = totalRow,
                TotalPage = totalPage
            };
            return View(paginationSet);
        }
    }
}