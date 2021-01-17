using generic_repository.Core.DataAccess.EntityFramework;
using generic_repository.Data.Abstract;
using generic_repository.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace generic_repository.Data.EntityFramework.Concrete
{
    public class EfProductRepository : EfRepositoryBase<Product, DatabaseContext>, IProductRepository
    {
        public EfProductRepository(DatabaseContext context): base(context)
        {

        }

        public IEnumerable<Product> GetByCategoryId(int categoryId)
        {
            return _context.Products.Where(x => x.CategoryId == categoryId).ToList();
        }
    }
}