using generic_repository.Business.Abstract;
using generic_repository.Business.Models.ResultModel;
using generic_repository.Data.Abstract;
using generic_repository.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace generic_repository.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public DataResult<Product> Create(Product product)
        {
            //Business logic... e.g. validation
            var result = _unitOfWork.Products.Insert(product);
            _unitOfWork.Commit();

            return new SuccessDataResult<Product>(result);
        }

        public IResult Delete(int id)
        {
            var product = _unitOfWork.Products.Get(x => x.Id == id);

            if (product == null)
                return new ErrorResult("Product not found");

            _unitOfWork.Products.Delete(product);
            _unitOfWork.Commit();

            return new SuccessResult();
        }

        public DataResult<Product> Get(int id)
        {
            var product = _unitOfWork.Products.Get(x => x.Id == id);

            if (product == null)
                return new ErrorDataResult<Product>("Product not found");

            return new SuccessDataResult<Product>(product);
        }

        public DataResult<IEnumerable<Product>> GetList()
        {
            var products = _unitOfWork.Products.GetList();

            return new SuccessDataResult<IEnumerable<Product>>(products);
        }

        public DataResult<Product> Update(Product product)
        {
            //Business logic... e.g. validation

            var currentProduct = _unitOfWork.Products.Get(x => x.Id == product.Id);
            if (currentProduct == null)
                return new ErrorDataResult<Product>("Product not found");

            //TODO use mapper instead
            currentProduct.Name = product.Name;
            currentProduct.Price = product.Price;
            currentProduct.Quantity = product.Quantity;

            _unitOfWork.Products.Update(currentProduct);
            _unitOfWork.Commit();

            return new SuccessDataResult<Product>(product);
        }
    }
}
