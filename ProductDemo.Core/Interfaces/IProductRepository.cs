using ProductDemo.Core.Models;

namespace ProductDemo.Core.Interfaces
{
    public interface IProductRepository : IGenericRepository<ProductDetails>
    {
    }
}