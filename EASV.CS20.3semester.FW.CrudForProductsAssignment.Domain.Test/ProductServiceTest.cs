using System.Collections.Generic;
using System.IO;
using EASV.CS20._3semester.FW.CrudForProductsAssignment.Core.IServices;
using EASV.CS20._3semester.FW.CrudForProductsAssignment.Core.Models;
using EASV.CS20._3semester.FW.CrudForProductsAssignment.Domain.IRepositories;
using EASV.CS20._3semester.FW.CrudForProductsAssignment.Domain.Services;
using Moq;
using Xunit;

namespace EASV.CS20._3semester.FW.CrudForProductsAssignment.Domain.Test
{
    public class ProductServiceTest
    {
        private readonly Mock<IProductRepository> _mock;
        private readonly ProductService _service;
        private List<Product> _products;

        public ProductServiceTest()
        {
            _mock = new Mock<IProductRepository>();
            _service = new ProductService(_mock.Object);
            _products = new List<Product>();
            _products.Add(new Product{Id = 1, Name = "shirt"});
            _products.Add(new Product{Id = 2, Name = "pants"});
        }

        [Fact]
        public void IsIProductService()
        {
            Assert.True(_service is IProductService);
        }

        [Fact]
        public void WithNullProductRepository_ThrowsInvalidDataException()
        {
            var exception = Assert.Throws<InvalidDataException>(
                () => new ProductService(null));
            Assert.Equal("ProductRepository cannot be null", exception.Message);
        }

        [Fact]
        public void GetProducts_CallsProductRepositoriesGetProducts_ExaclyOnce()
        {
            _service.GetProducts();
            _mock.Verify(r => r.GetProducts(), Times.Once);
        }

        [Fact]
        public void GetProducts_NoFilter_ReturnsListOfAllProducts()
        {
            _mock.Setup(r => r.GetProducts()).Returns(_products);
            Assert.Equal(_products, _service.GetProducts());
        }
    }}