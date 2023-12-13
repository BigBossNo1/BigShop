using Web.Data.Infrastructure;
using Web.Models.Models;

namespace Web.Data.Repositories
{
    public interface ITagRepository : IRepository<Tag>
    {
    }

    public class TagRepository : RepositoryBase<Tag>, ITagRepository
    {
        public TagRepository(IDbFactory dbFactory)
         : base(dbFactory)
        {
        }
    }
}