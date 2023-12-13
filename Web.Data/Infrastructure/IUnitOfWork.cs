namespace Web.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}