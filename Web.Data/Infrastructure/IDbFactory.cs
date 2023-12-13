using System;

namespace Web.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        ToanLeeShopDbContext Init();
    }
}