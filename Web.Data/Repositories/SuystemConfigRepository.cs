using Web.Data.Infrastructure;
using Web.Models.Models;

namespace Web.Data.Repositories
{
    public interface ISuystemConfigRepository : IRepository<SystemConfig>
    {
    }

    public class SuystemConfigRepository : RepositoryBase<SystemConfig>, ISuystemConfigRepository
    {
        public SuystemConfigRepository(IDbFactory dbFactory)
         : base(dbFactory)
        {
        }
    }
}