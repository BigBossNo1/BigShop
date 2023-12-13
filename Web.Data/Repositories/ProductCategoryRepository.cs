using System.Collections.Generic;
using System.Linq;
using Web.Data.Infrastructure;
using Web.Models.Models;

namespace Web.Data.Repositories
{
    public interface IProductCategoryRepository : IRepository<ProductCategorye>
    {
        IEnumerable<ProductCategorye> GetByAlias(string alias);
    }

    public class ProductCategoryRepository : RepositoryBase<ProductCategorye>, IProductCategoryRepository
    {
        public ProductCategoryRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }

        public IEnumerable<ProductCategorye> GetByAlias(string alias)
        {
            return this.DbContext.ProductCategoryes.Where(x => x.Alias == alias);
        }
    }
}