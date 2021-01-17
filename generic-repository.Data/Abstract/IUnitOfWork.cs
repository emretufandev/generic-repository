using System;
using System.Collections.Generic;
using System.Text;

namespace generic_repository.Data.Abstract
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        int Commit();
    }
}
