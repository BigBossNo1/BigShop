using Web.Data.Infrastructure;
using Web.Models.Models;

namespace Web.Data.Repositories
{
    public interface IVisitorStaticRepository : IRepository<VisitorStatic>
    {
    }

    public class VisitorStaticRepository : RepositoryBase<VisitorStatic>, IVisitorStaticRepository
    {
        public VisitorStaticRepository(IDbFactory dbFactory)
         : base(dbFactory)
        {
        }
    }
}