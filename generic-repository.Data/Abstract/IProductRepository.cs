using generic_repository.Core.DataAccess.Abstract;
using generic_repository.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace generic_repository.Data.Abstract
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IEnumerable<Product> GetByCategoryId(int categoryId);
    }
}
