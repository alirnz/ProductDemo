using System;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProductDemo;
using ProductDemo.Controllers;
using ProductDemo.Core.Models;
using ProductDemo.Services.Interfaces;

namespace ProductDemo.Test
{
	public class ProductsControllerTest
	{
        [Fact]
        public async Task GetProduct_WithValidId_ReturnsProductDetails()
        {

            // Arrange
            int testProductId = 123;
            var mockService = new Mock<IProductService>();
            mockService.Setup(repo => repo.GetProductById(testProductId))
                .ReturnsAsync(new ProductDetails { Id = testProductId }); // Configure the return value

            var controller = new ProductsController(mockService.Object);

            // Act
            var result = await controller.GetProductById(testProductId);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<ProductDetails>(okObjectResult.Value);
            Assert.Equal(123, returnValue.Id);


        }
        [Fact]
        public async Task GetAllProducts_ReturnListOfProducts()
        {

            // Arrange
           
            var mockService = new Mock<IProductService>();
            mockService.Setup(repo => repo.GetAllProducts())
                .ReturnsAsync(new List<ProductDetails>()); // Configure the return value

            var controller = new ProductsController(mockService.Object);

            // Act
            var result = await controller.GetProductList();

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<ProductDetails>>(okObjectResult.Value);
            Assert.NotNull(returnValue);



        }
    }
}

