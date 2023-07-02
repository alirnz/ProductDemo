using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductDemo.Core.Interfaces;
using ProductDemo.Core.Models;
using ProductDemo.Services.Interfaces;

namespace ProductDemo.Services
{
    public class ProductService : IProductService
    {
        public IProductsDemo _productDemo;

        public ProductService(IProductsDemo productDemo)
        {
            _productDemo = productDemo;
        }

        public async Task<bool> CreateProduct(ProductDetails productDetails)
        {
            if (productDetails != null)
            {
                await _productDemo.Products.Add(productDetails);

                var result = _productDemo.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            if (productId > 0)
            {
                var productDetails = await _productDemo.Products.GetById(productId);
                if (productDetails != null)
                {
                    _productDemo.Products.Delete(productDetails);
                    var result = _productDemo.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<ProductDetails>> GetAllProducts()
        {
            var productDetailsList = await _productDemo.Products.GetAll();
            return productDetailsList;
        }

        public async Task<ProductDetails?> GetProductById(int productId)
        {
            if (productId > 0)
            {
                var productDetails = await _productDemo.Products.GetById(productId);
                if (productDetails != null)
                {
                    return productDetails;
                }
            }
            return null;
        }

        public async Task<bool> UpdateProduct(ProductDetails productDetails)
        {
            if (productDetails != null)
            {
                var product = await _productDemo.Products.GetById(productDetails.Id);
                if(product != null)
                {
                    product.ProductName= productDetails.ProductName;
                    product.ProductDescription= productDetails.ProductDescription;
                    product.ProductPrice= productDetails.ProductPrice;
                    product.ProductStock= productDetails.ProductStock;

                    _productDemo.Products.Update(product);

                    var result = _productDemo.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
    }
}
