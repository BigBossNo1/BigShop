using System.Collections.Generic;
using Web.Data.Infrastructure;
using Web.Data.Repositories;
using Web.Models.Models;

namespace Web.Service
{
    public interface IPostCategoryService
    {
        PostCategorie Add(PostCategorie postCategory);

        void Update(PostCategorie postCategory);

        PostCategorie Delete(int id);

        IEnumerable<PostCategorie> GetAll();

        IEnumerable<PostCategorie> GetAllByParentId(int parentId);

        PostCategorie GetById(int id);

        void SaveChange();
    }

    // Service không phụ thuộc vào Repository mà cả hai đều phụ thuộc vào Interface IRepository//

    public class PostCategoryService : IPostCategoryService
    {
        private IPostCategoryeRepository _postCategoryeRepository;
        private IUnitOfWork _unitOfWork;

        public PostCategoryService(IPostCategoryeRepository postCategoryeRepository, IUnitOfWork unitOfWork)
        {
            this._postCategoryeRepository = postCategoryeRepository;
            this._unitOfWork = unitOfWork;
        }

        public PostCategorie Add(PostCategorie postCategory)
        {
            return _postCategoryeRepository.Add(postCategory);
        }

        public PostCategorie Delete(int id)
        {
           return _postCategoryeRepository.Delete(id);
        }

        public IEnumerable<PostCategorie> GetAll()
        {
            return _postCategoryeRepository.GetAll();
        }

        public IEnumerable<PostCategorie> GetAllByParentId(int parentId)
        {
            return _postCategoryeRepository.GetMulti(x => x.Status && x.ParentID == parentId);
        }

        public PostCategorie GetById(int id)
        {
            return _postCategoryeRepository.GetSingleById(id);
        }

        public void SaveChange()
        {
            _unitOfWork.Commit();
        }

        public void Update(PostCategorie postCategory)
        {
            _postCategoryeRepository.Update(postCategory);
        }

    }
}