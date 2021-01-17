using generic_repository.Business.Models.ResultModel;
using generic_repository.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace generic_repository.Business.Abstract
{
    public interface IProductService
    {
        DataResult<Product> Get(int id);
        DataResult<IEnumerable<Product>> GetList();
        DataResult<Product> Create(Product product);
        DataResult<Product> Update(Product product);
        IResult Delete(int id);
    }
}
