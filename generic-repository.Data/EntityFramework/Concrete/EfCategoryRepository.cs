using generic_repository.Core.DataAccess.EntityFramework;
using generic_repository.Data.Abstract;
using generic_repository.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace generic_repository.Data.EntityFramework.Concrete
{
    public class EfCategoryRepository : EfRepositoryBase<Category, DatabaseContext>, ICategoryRepository
    {
        public EfCategoryRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
