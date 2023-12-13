using Web.Data.Infrastructure;
using Web.Data.Repositories;
using Web.Models.Models;

namespace Web.Service
{
    public interface IErrorService
    {
        Error Create(Error error);

        void Save();
    }

    public class ErrorService : IErrorService
    {
        private IErrorRepository _erroRepository;
        private IUnitOfWork _unitOfWork;

        public ErrorService(IErrorRepository errorRepository, IUnitOfWork unitOfWork)
        {
            this._erroRepository = errorRepository;
            this._unitOfWork = unitOfWork;
        }

        // Construture
        public Error Create(Error error)
        {
            return _erroRepository.Add(error);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}