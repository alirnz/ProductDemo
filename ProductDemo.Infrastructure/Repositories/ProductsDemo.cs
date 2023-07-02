using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDemo.Core.Interfaces;
using ProductDemo.Infrastructure;

namespace ProductDemo.Infrastructure.Repositories
{
    public class ProductsDemo : IProductsDemo
    {
        private readonly DbContextClass _dbContext;
        public IProductRepository Products { get; }

        public ProductsDemo(DbContextClass dbContext,
                            IProductRepository productRepository)
        {
            _dbContext = dbContext;
            Products = productRepository;
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }

    }
}
