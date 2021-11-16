using System.Collections.Generic;
using System.IO;
using EASV.CS20._3semester.FW.CrudForProductsAssignment.Core.IServices;
using EASV.CS20._3semester.FW.CrudForProductsAssignment.Core.Models;
using EASV.CS20._3semester.FW.CrudForProductsAssignment.Domain.IRepositories;
using EASV.CS20._3semester.FW.CrudForProductsAssignment.Domain.Services;
using Moq;
using Xunit;

namespace EASV.CS20._3semester.FW.CrudForProductsAssignment.Domain.Test.ServiceTest
{
    public class ProductServiceTest
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly ProductService _productService;
        private readonly List<Product> _products;

        public ProductServiceTest()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _productService = new ProductService(_productRepositoryMock.Object);

            _products = new List<Product>();
            _products.Add(new Product()
            {
                Id = 1,
                Name = "Product1"
            });
            _products.Add(new Product()
            {
                Id = 2,
                Name = "Product2"
            });
            _products.Add(new Product()
            {
                Id = 3,
                Name = "Product3"
            });
        }

        #region Initialization Test
    
        [Fact]
        public void ProductService_CanBeInitialized()
        {
            // Assert
            Assert.NotNull(_productService);
        }
    
        [Fact]
        public void ProductService_ImplementInterface()
        {
            // Assert
            Assert.True(_productService is IProductService);
            
        }
        #endregion

        #region Dependency Injection Test

        [Fact]
        public void ProductService_DI_IRepository_NotNull()
        {
            // Assert
            Assert.NotNull(_productRepositoryMock);
            Assert.NotNull(_productService);
            
        }

        [Fact]
        public void ProductService_DI_IRepository_IsNull_ThrowsException()
        {
            // Arrange
            // Act
            var invalidDataException = Assert.Throws<InvalidDataException>(() => new ProductService(null));
            
            // Assert
            Assert.Equal("The Repository can not be null", invalidDataException.Message);
        }

        #endregion

        #region Service Test

        [Fact]
        public void ProductService_Add_ParameterProduct_ReturnProduct()
        {
            // Arrange
            var product = new Product()
            {
                Id = 4,
                Name = "Product4"
            };
            _productRepositoryMock.Setup(repository => repository.CreateProduct(product))
                .Returns(product);
            
            // Act
            var actual = _productService.CreateProduct(product);
            
            // Assert
            Assert.Equal(product,actual);
        }


        [Fact]
        public void ProductService_GetAll_NoParameter_ReturnListOfProducts()
        {
            // Arrange
            _productRepositoryMock.Setup(repository => repository.GetProducts())
                .Returns(_products);
            // Act
            var actual = _productService.GetProducts();
            // Assert
            Assert.Equal(_products,actual);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void ProductService_GetById_ParameterId_ReturnProduct(int id)
        {
            // Arrange
            var find = _products.Find(product => product.Id == id);
            _productRepositoryMock.Setup(repository => repository.GetProductById(id))
                .Returns(find);
            // Act
            var actual = _productService.GetProductById(id);
            // Assert
            Assert.Equal(find,actual);
            
        }

        [Theory]
        [InlineData(1, "name1")]
        [InlineData(2, "name2")]
        [InlineData(3, "name3")]
        public void ProductService_Modify_ParameterProduct_ReturnProduct(int id, string name)
        {
            // Arrange
            var changeProduct = new Product()
            {
                Id = id,
                Name = name
            };
            
            _productRepositoryMock.Setup(repository => repository.UpdateProduct(changeProduct))
                .Returns(changeProduct);
            // Act
            var actual = _productService.UpdateProduct(changeProduct);
            // Assert
            Assert.Equal(changeProduct,actual);
            
        }

        [Fact]
        public void ProductService_Delete_ParameterProduct_ReturnProduct()
        {
            // Arrange
            var product = new Product()
            {
                Id = 1,
                Name = "name"
            };
            _productRepositoryMock.Setup(repository => repository.GetProductById(product.Id))
                .Returns(product);
            _productRepositoryMock.Setup(repository => repository.RemoveProduct(product.Id))
                .Returns(product);
            // Act
            var actual = _productService.RemoveProduct(product.Id);
            // Assert
            Assert.Equal(product,actual);
        }
        
        
        #endregion
    }
}