using generic_repository.Business.Models.ResultModel;
using generic_repository.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace generic_repository.Business.Abstract
{
    public interface ICategoryService
    {
        DataResult<Category> Get(int id);
        DataResult<IEnumerable<Category>> GetList();
        DataResult<IEnumerable<Product>> GetProducts(int categoryId);
        DataResult<Category> Create(Category product);
        DataResult<Category> Update(Category product);
        IResult Delete(int id);
    }
}
