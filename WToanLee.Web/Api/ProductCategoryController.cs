using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web.Models.Models;
using Web.Service;
using WToanLee.Web.Infrastructure.Core;
using WToanLee.Web.Infrastructure.Extensions;
using WToanLee.Web.Models;

namespace WToanLee.Web.Api
{
    [RoutePrefix("api/productcategory")]
    public class ProductCategoryController : ApiControllerBase
    {
        private IProductCategoryService _productCategoryService;

        public ProductCategoryController(IErrorService errorService, IProductCategoryService productCategoryService)
            : base(errorService)
        {
            this._productCategoryService = productCategoryService;
        }

        [Route("getallparentId")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _productCategoryService.GetAll();
                var responseData = Mapper.Map<IEnumerable<ProductCategorye>, IEnumerable<ProductCategoryViewModel>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        // lay ra ID
        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _productCategoryService.GetById(id);
                var responseData = Mapper.Map<ProductCategorye, ProductCategoryViewModel>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword)
        {
            return CreateHttpResponse(request, () =>
            {
                // Cmt nhiều là do chưa phân đc trang
                int totalRow = 0;

                var model = _productCategoryService.GetAll(keyword);
                //var model = _productCategoryService.GetAll();

                //đếm xem có bao nhiêu bản ghi
                totalRow = model.Count();
                // lấy ra từng trang một
                //-- hàm thực thi
                //var query = model.OrderByDescending(x => x.CreateDate).Skip(page * pageSize).Take(pageSize);

                // mapping 2 class với nhau
                var responseData = Mapper.Map<IEnumerable<ProductCategorye>, IEnumerable<ProductCategoryViewModel>>(model);
                // gọi đối tượng pagenationSet trong InfrasTructure / Core
                // -- hàm thực thi
                var totalCount = totalRow;
                //var pagenationSet = new PagenationSet<ProductCategoryViewModel>()
                //{
                //    Items = responseData,
                //    Page = page,
                //    TotalCount = totalRow,
                //    TotalPage = (int)Math.Ceiling((decimal)totalRow / pageSize)
                //};

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, ProductCategoryViewModel productCategoryViewModel)
        {
            return CreateHttpResponse(request, () =>
            {
                // neu ma khoong co gia tri truyen vao thi thong bao loi
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var newProductCategory = new ProductCategorye();
                    newProductCategory.UpdateProductCategory(productCategoryViewModel);
                    newProductCategory.CreateDate = System.DateTime.Now;

                    _productCategoryService.Add(newProductCategory);
                    _productCategoryService.Save();

                    var resposeData = Mapper.Map<ProductCategorye, ProductCategoryViewModel>(newProductCategory);
                    response = request.CreateResponse(HttpStatusCode.Created, resposeData);
                }

                return response;
            });
        }

        // Update du lieu
        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, ProductCategoryViewModel productCategoryViewModel)
        {
            return CreateHttpResponse(request, () =>
            {
                // neu ma khoong co gia tri truyen vao thi thong bao loi
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var dbProductCategory = _productCategoryService.GetById(productCategoryViewModel.ID);
                    dbProductCategory.UpdateProductCategory(productCategoryViewModel);
                    dbProductCategory.CreateDate = System.DateTime.Now;

                    _productCategoryService.Update(dbProductCategory);
                    _productCategoryService.Save();

                    var resposeData = Mapper.Map<ProductCategorye, ProductCategoryViewModel>(dbProductCategory);
                    response = request.CreateResponse(HttpStatusCode.Created, resposeData);
                }

                return response;
            });
        }

        // Xóa dữ liệu
        [Route("delete")]
        [HttpDelete]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                // neu ma khoong co gia tri truyen vao thi thong bao loi
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var oldProductcategory = _productCategoryService.Delete(id);
                    _productCategoryService.Save();

                    var resposeData = Mapper.Map<ProductCategorye, ProductCategoryViewModel>(oldProductcategory);
                    response = request.CreateResponse(HttpStatusCode.Created, resposeData);
                }

                return response;
            });
        }
    }
}