using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;
using Web.Models.Models;
using Web.Service;
using WToanLee.Web.Models;

namespace WToanLee.Web.Controllers
{
    public class HomeClientController : Controller
    {
        private IProductCategoryService _iproducCategoryService;
        private ICommonService _commonService;
        private IProductService  _iproductServive;

        public HomeClientController(IProductCategoryService productCategoryService , ICommonService commonService , IProductService productService)
        {
            _iproducCategoryService = productCategoryService;
            _commonService = commonService;
            _iproductServive = productService;
        }

        // GET: HomeClient
        public ActionResult Index()
        {
            var slideModel = _commonService.GetSlide();
            var slideView = Mapper.Map<IEnumerable<Slide>, IEnumerable<SlideViewModel>>(slideModel);
            var homeViewModel = new HomeViewModel();
            homeViewModel.Slides = slideView;

            var lasttestProductModel = _iproductServive.GetLastest(2);
            var topSaleProductModel = _iproductServive.GetHotProduct(2);
            var lasttestProductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(lasttestProductModel);
            var topSaleProductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(topSaleProductModel);
            homeViewModel.lastestProduct = lasttestProductViewModel;
            homeViewModel.topSaleProduct = topSaleProductViewModel;
            return View(homeViewModel);
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            var model = _iproducCategoryService.GetAll();
            var listProductCategoryViewModel = Mapper.Map<IEnumerable<ProductCategorye>, IEnumerable<ProductCategoryViewModel>>(model);
            return PartialView(listProductCategoryViewModel);
        }

        [ChildActionOnly]
        public ActionResult Header()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult Category()
        {
            var model = _iproducCategoryService.GetAll();
            var listProductCategoryViewModel = Mapper.Map<IEnumerable<ProductCategorye>, IEnumerable<ProductCategoryViewModel>>(model);
            return PartialView(listProductCategoryViewModel);
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}