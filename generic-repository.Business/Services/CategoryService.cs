using generic_repository.Business.Abstract;
using generic_repository.Business.Models.ResultModel;
using generic_repository.Data.Abstract;
using generic_repository.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace generic_repository.Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public DataResult<Category> Create(Category category)
        {
            //Business logic... e.g. validation
            var result = _unitOfWork.Categories.Insert(category);
            _unitOfWork.Commit();

            return new SuccessDataResult<Category>(result);
        }

        public IResult Delete(int id)
        {
            var category = _unitOfWork.Categories.Get(x => x.Id == id);

            if (category == null)
                return new ErrorResult("Category not found");

            _unitOfWork.Categories.Delete(category);
            _unitOfWork.Commit();

            return new SuccessResult();
        }

        public DataResult<Category> Get(int id)
        {
            var category = _unitOfWork.Categories.Get(x => x.Id == id);

            if (category == null)
                return new ErrorDataResult<Category>("Category not found");

            return new SuccessDataResult<Category>(category);
        }

        public DataResult<IEnumerable<Category>> GetList()
        {
            var categories = _unitOfWork.Categories.GetList();

            return new SuccessDataResult<IEnumerable<Category>>(categories);
        }

        public DataResult<IEnumerable<Product>> GetProducts(int categoryId)
        {
            var products = _unitOfWork.Products.GetByCategoryId(categoryId);

            return new SuccessDataResult<IEnumerable<Product>>(products);
        }

        public DataResult<Category> Update(Category category)
        {
            //Business logic... e.g. validation

            var currentCategory = _unitOfWork.Categories.Get(x => x.Id == category.Id);
            if (currentCategory == null)
                return new ErrorDataResult<Category>("Category not found");

            //TODO use mapper instead
            currentCategory.Name = category.Name;

            _unitOfWork.Categories.Update(currentCategory);
            _unitOfWork.Commit();

            return new SuccessDataResult<Category>(category);
        }
    }
}
