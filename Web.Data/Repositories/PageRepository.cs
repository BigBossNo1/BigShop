using Web.Data.Infrastructure;
using Web.Models.Models;

namespace Web.Data.Repositories
{
    public interface IPageRepository : IRepository<Pages>
    {
    }

    public class PageRepository : RepositoryBase<Pages>, IPageRepository
    {
        public PageRepository(IDbFactory dbFactory)
         : base(dbFactory)
        {
        }
    }
}