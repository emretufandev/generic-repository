using generic_repository.Data.Abstract;
using generic_repository.Data.EntityFramework;
using generic_repository.Data.EntityFramework.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace generic_repository.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;

        private IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;
        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }
        public IProductRepository Products => _productRepository ?? new EfProductRepository(_context);

        public ICategoryRepository Categories => _categoryRepository ?? new EfCategoryRepository(_context);

        public int Commit()
        {
            return _context.SaveChanges();
        }
    }
}
