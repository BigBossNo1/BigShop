using System.Collections;
using System.Collections.Generic;
using Web.Data.Infrastructure;
using Web.Models.Models;
using System.Linq;

namespace Web.Data.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetListProductByTag(string tagID , int page, int pageSize, out int totalRow);
    }

    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDbFactory dbFactory)
         : base(dbFactory)
        {
        }

        public IEnumerable<Product> GetListProductByTag(string tagID, int page, int pageSize, out int totalRow)
        {
            var query = from p in DbContext.Products join pt in DbContext.ProductTags
                        on p.ID equals pt.ProductID
                        where pt.TagID == tagID
                        select p;
            totalRow = query.Count();
            return query.OrderBy(x=>x.CreateDate).Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}