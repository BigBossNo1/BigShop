using AutoMapper;
using System.Collections.Generic;
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
    [RoutePrefix("api/product")]
    public class ProductController : ApiControllerBase
    {
        private IProductService _productService;

        public ProductController(IErrorService errorService, IProductService productService)
            : base(errorService)
        {
            this._productService = productService;
        }

        // lấy ra id của lớp cha
        [Route("getallparentId")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _productService.GetAll();
                var responseData = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(model);
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
                var model = _productService.GetById(id);
                var responseData = Mapper.Map<Product, ProductViewModel>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        // lấy ra toàn bộ danh sách product
        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyWord)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _productService.GetAll(keyWord);
                var responseData = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(model);
                var respon = request.CreateResponse(HttpStatusCode.OK, responseData);
                return respon;
            });
        }

        // thêm mới dữ liệu
        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, ProductViewModel productViewModel)
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
                    var newProduct = new Product();
                    newProduct.UpdateProduct(productViewModel);
                    newProduct.CreateDate = System.DateTime.Now;

                    _productService.Add(newProduct);
                    _productService.Save();

                    var resposeData = Mapper.Map<Product, ProductViewModel>(newProduct);
                    response = request.CreateResponse(HttpStatusCode.Created, resposeData);
                }

                return response;
            });
        }

        // Update dữ liệu
        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, ProductViewModel productViewModel)
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
                    var dbProduct = _productService.GetById(productViewModel.ID);
                    dbProduct.UpdateProduct(productViewModel);
                    dbProduct.CreateDate = System.DateTime.Now;

                    _productService.Update(dbProduct);
                    _productService.Save();

                    var resposeData = Mapper.Map<Product, ProductViewModel>(dbProduct);
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
                    var oldProduct = _productService.Delete(id);
                    _productService.Save();

                    var resposeData = Mapper.Map<Product, ProductViewModel>(oldProduct);
                    response = request.CreateResponse(HttpStatusCode.Created, resposeData);
                }

                return response;
            });
        }
    }
}