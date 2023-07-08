using ProductDemo.Core.Interfaces;
using ProductDemo.Core.Models;
using ProductDemo.Services;
using ProductDemo.Services.Interfaces;
using Xunit;
using System.Threading.Tasks;
using Moq;

namespace ProductDemo.Test
{

    // Test class
    [Collection("ProductServiceCollection")]
    public class ProductServiceTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(21)]
        [InlineData(15)]
        [InlineData(25)]
        public async Task Product_Service_GetProductById_Should_Return_ValueAsync(int inputProductId)
        {
            // Arrange
            var productId = inputProductId;
            var productDetails = new ProductDetails { Id = productId };
            var productDemoMock = new Mock<IProductsDemo>();
            productDemoMock.Setup(p => p.Products.GetById(productId))
                .ReturnsAsync(productDetails);

            var productService = new ProductService(productDemoMock.Object);

            // Act
            var result_product = await productService.GetProductById(productId);

            // Assert
            Assert.Equal(productDetails, result_product);
            productDemoMock.Verify(p => p.Products.GetById(productId), Times.Once);
        }
    }
}
