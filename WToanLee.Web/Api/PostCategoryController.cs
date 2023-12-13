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
    [RoutePrefix("api/postcategory")]
    public class PostCategoryController : ApiControllerBase
    {
        private IPostCategoryService _productCategoryService;

        public PostCategoryController(IErrorService errorService, IPostCategoryService productCategoryService)
            : base(errorService)
        {
            this._productCategoryService = productCategoryService;
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var listCategory = _productCategoryService.GetAll();
                var listPoscategoryViewModel = Mapper.Map<List<PostcategoryViewModel>>(listCategory);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listPoscategoryViewModel);

                return response;
            });
        }

        [Route("add")]
        public HttpResponseMessage Post(HttpRequestMessage request, PostcategoryViewModel postCategoryVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    PostCategorie newPostCategory = new PostCategorie();
                    newPostCategory.UpdatePostCategory(postCategoryVm);
                    var category = _productCategoryService.Add(newPostCategory);
                    _productCategoryService.SaveChange();
                    response = request.CreateResponse(HttpStatusCode.Created, category);
                }

                return response;
            });
        }

        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, PostcategoryViewModel postCategoryVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var postCategoryDb = _productCategoryService.GetById(postCategoryVm.ID);
                    postCategoryDb.UpdatePostCategory(postCategoryVm);
                    _productCategoryService.Update(postCategoryDb);
                    _productCategoryService.SaveChange();
                    response = request.CreateResponse(HttpStatusCode.OK);
                }

                return response;
            });
        }

        public HttpResponseMessage Delete(HttpRequestMessage request, int Id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _productCategoryService.Delete(Id);
                    _productCategoryService.SaveChange();
                    response = request.CreateResponse(HttpStatusCode.OK);
                }

                return response;
            });
        }
    }
}