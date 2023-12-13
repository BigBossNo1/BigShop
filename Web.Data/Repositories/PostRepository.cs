using System.Collections.Generic;
using System.Linq;
using Web.Data.Infrastructure;
using Web.Models.Models;

namespace Web.Data.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        IEnumerable<Post> GetAllByTag(string tag, int pageIndex, int pageSize, out int totalRaw);
    }

    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(IDbFactory dbFactory)
         : base(dbFactory)
        {
        }

        public IEnumerable<Post> GetAllByTag(string tag, int pageIndex, int pageSize, out int totalRaw)
        {
            var query = from p in DbContext.Posts
                        join pt in DbContext.postTags
                        on p.ID equals pt.PostID
                        where pt.TagID == tag && p.Status
                        orderby p.CreateDate descending
                        // Theo thu tu giam dan theo ngay tao
                        select p;
            // câu lệnh truy vấn
            totalRaw = query.Count();
            // Đếm xem có bao nhiêu bản ghi
            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            // cách phân trang xem 1 trang có bao nhiêu bản ghi
            return query;
            
        }
    }
}