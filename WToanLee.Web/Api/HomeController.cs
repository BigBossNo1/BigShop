using System.Web.Http;
using Web.Service;
using WToanLee.Web.Infrastructure.Core;

namespace WToanLee.Web.Api
{
    [RoutePrefix("api/home")]
    [Authorize]
    public class HomeController : ApiControllerBase
    {
        IErrorService _errorService;
        public HomeController(IErrorService errorService) : base(errorService)
        {
            this._errorService = errorService;
        }

        [HttpGet]
        [Route("TestMethod")]
        public string TestMethod()
        {
            return "Hello, ToanLee Member. ";
        }
    }
}