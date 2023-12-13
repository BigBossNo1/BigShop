namespace Web.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        // Kiểu lấy ra đối tượng ToanLeeShopDbContext()
        private ToanLeeShopDbContext _DbContex;

        public ToanLeeShopDbContext Init()
        {
            return _DbContex ?? (_DbContex = new ToanLeeShopDbContext());
        }

        protected override void DisposeCore()
        {
            if (_DbContex != null)
            {
                _DbContex.Dispose();
            }
        }
    }
}