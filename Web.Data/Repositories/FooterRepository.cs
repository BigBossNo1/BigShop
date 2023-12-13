using Web.Data.Infrastructure;
using Web.Models.Models;

namespace Web.Data.Repositories
{
    public interface IFooterReposetory : IRepository<Footer>
    {
    } 
    public class FooterReposetory : RepositoryBase<Footer>, IFooterReposetory
    {
        public FooterReposetory(IDbFactory dbFactory)
         : base(dbFactory)
        {
        }
    }
}