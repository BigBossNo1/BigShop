using AutoMapper;
using System;
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
    [RoutePrefix("api/post")]
    public class PostController : ApiControllerBase
    {
        private IPostService _IPostService;

        // constructor
        public PostController(IErrorService errorService, IPostService postService)
        : base(errorService)
        {
            this._IPostService = postService;
        }

        // lấy ra toàn bộ danh sách post
        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request , string keyWord)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _IPostService.GetAll(keyWord);
                var responseData = Mapper.Map<IEnumerable<Post> , IEnumerable<PostViewModel>>(model);
                var respon = request.CreateResponse(HttpStatusCode.OK, responseData);
                return respon;
            });
        }

        // thêm mới 1 bản ghi post
        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, PostViewModel postViewModel)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.Created, ModelState);
                }
                else
                {
                    var newPost = new Post();
                    newPost.UpdatePost(postViewModel);
                    newPost.CreateDate = DateTime.Now;
                    _IPostService.Add(newPost);
                    _IPostService.SaveChanges();

                    var resposeData = Mapper.Map<Post, PostViewModel>(newPost);
                    response = request.CreateResponse(HttpStatusCode.Created, resposeData);
                }
                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, PostViewModel postViewModel)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var dbPost = _IPostService.GetById(postViewModel.ID);
                    dbPost.UpdatePost(postViewModel);
                    dbPost.CreateDate = System.DateTime.Now;

                    _IPostService.Update(dbPost);
                    _IPostService.SaveChanges();

                    var resposeData = Mapper.Map<Post, PostViewModel>(dbPost);

                    response = request.CreateResponse(HttpStatusCode.Created, resposeData);
                }
                return response;
            });
        }
    }
}