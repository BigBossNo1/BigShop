using Web.Data.Infrastructure;
using Web.Models.Models;

namespace Web.Data.Repositories
{
    public interface ISopportOnlineRepository : IRepository<SupportOnline>
    {
    }

    public class SopportOnlineRepository : RepositoryBase<SupportOnline>, ISopportOnlineRepository
    {
        public SopportOnlineRepository(IDbFactory dbFactory)
         : base(dbFactory)
        {
        }
    }
}