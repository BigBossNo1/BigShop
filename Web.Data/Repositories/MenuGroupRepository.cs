using Web.Data.Infrastructure;
using Web.Models.Models;

namespace Web.Data.Repositories
{
    public interface IMenuGroupRepository :  IRepository<MenuGroup>
    {
    }
    public class MenuGroupRepository : RepositoryBase<MenuGroup>, IMenuGroupRepository
    {
        public MenuGroupRepository(IDbFactory dbFactory)
         : base(dbFactory)
        {
        }
    }
}