using ProductDemo.Core.Interfaces;
using ProductDemo.Core.Models;

namespace ProductDemo.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<ProductDetails>, IProductRepository
    {
        public ProductRepository(DbContextClass dbContext) : base(dbContext)
        {

        }
    }
}
