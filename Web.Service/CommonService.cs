using System.Collections.Generic;
using Web.Data.Infrastructure;
using Web.Data.Repositories;
using Web.Models.Models;

namespace Web.Service
{
    public interface ICommonService
    {
        IEnumerable<Slide> GetSlide();
    }

    public class CommonService : ICommonService
    {
        private ISlideRepository _slideRepository;
        private IUnitOfWork _unitOfWork;

        public CommonService(ISlideRepository slideRepository, IUnitOfWork unitOfWork)
        {
            _slideRepository = slideRepository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Slide> GetSlide()
        {
            return _slideRepository.GetMulti(x => x.Status);
        }
    }
}