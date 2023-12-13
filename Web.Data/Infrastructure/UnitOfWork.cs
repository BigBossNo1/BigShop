namespace Web.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        // Partern lưu lại SavaChange()
        private readonly IDbFactory dbFactory;

        private ToanLeeShopDbContext _DbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public ToanLeeShopDbContext DbContext
        {
            get { return _DbContext ?? (_DbContext = dbFactory.Init()); }
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}