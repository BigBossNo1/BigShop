using System.Collections.Generic;
using Web.Data.Infrastructure;
using Web.Data.Repositories;
using Web.Models.Models;

namespace Web.Service
{
    public interface IProductCategoryService
    {
        ProductCategorye Add(ProductCategorye ProductCategory);

        void Update(ProductCategorye ProductCategory);

        ProductCategorye Delete(int id);

        IEnumerable<ProductCategorye> GetAll();

        IEnumerable<ProductCategorye> GetAll(string keyWord);

        IEnumerable<ProductCategorye> GetAllByParentId(int parentId);

        ProductCategorye GetById(int id);

        void Save();
    }

    // Service không phụ thuộc vào Repository mà cả hai đều phụ thuộc vào Interface IRepository//

    public class ProductCategoryService : IProductCategoryService
    {
        private IProductCategoryRepository _ProductCategoryeRepository;
        private IUnitOfWork _unitOfWork;

        public ProductCategoryService(IProductCategoryRepository ProductCategoryeRepository, IUnitOfWork unitOfWork)
        {
            this._ProductCategoryeRepository = ProductCategoryeRepository;
            this._unitOfWork = unitOfWork;
        }

        public ProductCategorye Add(ProductCategorye ProductCategory)
        {
            return _ProductCategoryeRepository.Add(ProductCategory);
        }

        public ProductCategorye Delete(int id)
        {
            return _ProductCategoryeRepository.Delete(id);
        }

        public IEnumerable<ProductCategorye> GetAll()
        {
            return _ProductCategoryeRepository.GetAll();
        }

        // tìm kiếm danh sách theo tên đầu vào
        public IEnumerable<ProductCategorye> GetAll(string keyWord)
        {
            if (!string.IsNullOrEmpty(keyWord))
            {
                return _ProductCategoryeRepository.GetMulti(x => x.Name.Contains(keyWord) || x.Description.Contains(keyWord));
            }
            else
            {
                return _ProductCategoryeRepository.GetAll();
            }
        }

        public IEnumerable<ProductCategorye> GetAllByParentId(int parentId)
        {
            return _ProductCategoryeRepository.GetMulti(x => x.Status && x.ParentID == parentId);
        }

        public ProductCategorye GetById(int id)
        {
            return _ProductCategoryeRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(ProductCategorye ProductCategory)
        {
            _ProductCategoryeRepository.Update(ProductCategory);
        }
    }
}