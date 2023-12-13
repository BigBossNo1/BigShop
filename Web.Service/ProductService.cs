using System.Collections.Generic;
using System.Linq;
using Web.Common;
using Web.Data.Infrastructure;
using Web.Data.Repositories;
using Web.Models.Models;

namespace Web.Service
{
    public interface IProductService
    {
        Product Add(Product Product);

        void Update(Product Product);

        Product Delete(int id);

        IEnumerable<Product> GetAll();

        IEnumerable<Product> GetAll(string keyWord);

        IEnumerable<Product> GetListProductByCategoryIdPage(int categryID, int page, int pageSize, string sort, out int totalRow);

        IEnumerable<Product> Search(string keyword, int page, int pageSize, string sort, out int totalRow);

        IEnumerable<string> GetListProductByName(string name);

        IEnumerable<Product> GetReatedProduct(int id, int top);

        IEnumerable<Product> GetLastest(int top);

        IEnumerable<Product> GetHotProduct(int top);

        Product GetById(int id);

        void Save();
        Tag getTag(string tagID);

        // laay ra tag
        IEnumerable<Tag> GetListTagProductID(int id);

        IEnumerable<Product> GetListProductByTag(string tagID, int page, int pageSize, out int totalRow);
    }

    public class ProductService : IProductService
    {
        private IProductRepository _ProductRepository;
        private ITagRepository _tagRepository;
        private IProductTagRepository _productTagRepository;
        private IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository ProductRepository, ITagRepository tagRepository, IProductTagRepository productTagRepository, IUnitOfWork unitOfWork)
        {
            this._ProductRepository = ProductRepository;
            this._tagRepository = tagRepository;
            this._productTagRepository = productTagRepository;
            this._unitOfWork = unitOfWork;
        }

        public Product Add(Product Product)
        {
            // vì mới vào chưa có id nên cần phải thêm trước;
            var product = _ProductRepository.Add(Product);
            _unitOfWork.Commit();
            if (!string.IsNullOrEmpty(Product.Tags))
            {
                string[] tags = Product.Tags.Split(',');
                for (var i = 0; i < tags.Length; i++)
                {
                    var tagId = StringHelper.ToUnsignString(tags[i]);
                    if (_tagRepository.Count(x => x.ID == tagId) == 0)
                    {
                        Tag tag = new Tag();
                        tag.ID = tagId;
                        tag.Name = tags[i];
                        tag.Type = CommonConstants.ProductTag;
                        _tagRepository.Add(tag);
                    }

                    ProductTag productTag = new ProductTag();
                    productTag.ProductID = Product.ID;
                    productTag.TagID = tagId;
                    _productTagRepository.Add(productTag);
                }
            }
            return product;
        }

        public Product Delete(int id)
        {
            return _ProductRepository.Delete(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _ProductRepository.GetAll();
        }

        // tìm kiếm danh sách theo tên đầu vào
        public IEnumerable<Product> GetAll(string keyWord)
        {
            if (!string.IsNullOrEmpty(keyWord))
            {
                return _ProductRepository.GetMulti(x => x.Name.Contains(keyWord) || x.Description.Contains(keyWord));
            }
            else
            {
                return _ProductRepository.GetAll();
            }
        }

        public Product GetById(int id)
        {
            return _ProductRepository.GetSingleById(id);
        }

        public IEnumerable<Product> GetHotProduct(int top)
        {
            return _ProductRepository.GetMulti(x => x.Status && x.HotFlag == true).OrderByDescending(x => x.CreateDate).Take(top);
        }

        public IEnumerable<Product> GetLastest(int top)
        {
            return _ProductRepository.GetMulti(x => x.Status).OrderByDescending(x => x.CreateDate).Take(top);
        }

        public IEnumerable<Product> GetListProductByCategoryIdPage(int categryID, int page, int pageSize, string sort, out int totalRow)
        {
            // lay danh sach
            var query = _ProductRepository.GetMulti(x => x.Status && x.CategoryID == categryID);
            // dem tong dong
            switch (sort)
            {
                case "popular":
                    query = query.OrderByDescending(x => x.ViewCount);
                    break;

                case "discount":
                    query = query.OrderByDescending(x => x.PromotionPrice.HasValue);
                    break;

                case "price":
                    query = query.OrderBy(x => x.Price);
                    break;

                default:
                    query = query.OrderByDescending(x => x.CreateDate);
                    break;
            }
            totalRow = query.Count();
            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public IEnumerable<string> GetListProductByName(string name)
        {
            return _ProductRepository.GetMulti(x => x.Status && x.Name.Contains(name)).Select(y => y.Name);
        }

        public IEnumerable<Product> GetListProductByTag(string tagID, int page, int pageSize, out int totalRow)
        {
            var model = _ProductRepository.GetListProductByTag(tagID, page, pageSize, out  totalRow);
            return model;
        }

        public IEnumerable<Tag> GetListTagProductID(int id)
        {
            return _productTagRepository.GetMulti(x => x.ProductID == id, new string[] { "Tags" }).Select(y => y.Tags);
        }

        public IEnumerable<Product> GetReatedProduct(int id, int top)
        {
            var product = _ProductRepository.GetSingleById(id);
            return _ProductRepository.GetMulti(x => x.Status && x.ID != id && x.CategoryID == product.CategoryID).OrderByDescending(x => x.CreateDate).Take(top);
        }

        public Tag getTag(string tagID)
        {
            return _tagRepository.GetSingleByCondition(x=>x.ID == tagID);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<Product> Search(string keyword, int page, int pageSize, string sort, out int totalRow)
        {
            // lay danh sach
            var query = _ProductRepository.GetMulti(x => x.Status && x.Name.Contains(keyword));
            // dem tong dong
            switch (sort)
            {
                case "popular":
                    query = query.OrderByDescending(x => x.ViewCount);
                    break;

                case "discount":
                    query = query.OrderByDescending(x => x.PromotionPrice.HasValue);
                    break;

                case "price":
                    query = query.OrderBy(x => x.Price);
                    break;

                default:
                    query = query.OrderByDescending(x => x.CreateDate);
                    break;
            }
            totalRow = query.Count();
            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public void Update(Product Product)
        {
            _ProductRepository.Update(Product);
            if (!string.IsNullOrEmpty(Product.Tags))
            {
                //tach ra theo dau phay
                string[] tags = Product.Tags.Split(',');
                for (var i = 0; i < tags.Length; i++)
                {
                    // nếu không có id nào trùng thì thêm mới tag
                    var tagId = StringHelper.ToUnsignString(tags[i]);
                    if (_tagRepository.Count(x => x.ID == tags[i]) == 0)
                    {
                        Tag tag = new Tag();
                        tag.ID = tagId;
                        tag.Name = tags[i];
                        tag.Type = CommonConstants.ProductTag;
                        _tagRepository.Add(tag);
                    }
                    // trước khi thêm thì phải xóa
                    _productTagRepository.DeleteMulti(x => x.ProductID == Product.ID);
                    // Thêm mới vào bảng ProductTag
                    ProductTag productTag = new ProductTag();
                    productTag.ProductID = Product.ID;
                    productTag.TagID = tagId;
                    _productTagRepository.Add(productTag);
                }
            }
            _unitOfWork.Commit();
        }
    }
}