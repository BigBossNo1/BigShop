using Web.Data.Infrastructure;
using Web.Models.Models;

namespace Web.Data.Repositories
{
    public interface IPostCategoryeRepository : IRepository<PostCategorie>
    {

    }

    public class PostCategoryeRepository : RepositoryBase<PostCategorie>, IPostCategoryeRepository
    {
        public PostCategoryeRepository(IDbFactory dbFactory)
         : base(dbFactory)
        {
            
        }
    }
}