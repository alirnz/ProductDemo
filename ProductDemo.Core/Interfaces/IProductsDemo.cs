

namespace ProductDemo.Core.Interfaces
{
    public interface IProductsDemo : IDisposable
    {
        IProductRepository Products { get; }

        int Save();
    }
}
