using System.Collections.Generic;
using EASV.CS20._3semester.FW.CrudForProductsAssignment.Core.IServices;
using EASV.CS20._3semester.FW.CrudForProductsAssignment.Core.Models;
using Moq;
using Xunit;

namespace EASV.CS20._3semester.FW.CrudForProductsAssignment.Core.Test.IServiceTest
{
    public class IProductServiceTest
    {
        #region Interface Avaliable Test

        [Fact]
        public void IProductService_IsAvailable()
        {
            // Arrange
            var mock = new Mock<IProductService>();
            
            // Act
            var productService = mock.Object;
            
            // Assert
            Assert.NotNull(productService);
        }

        #endregion

        #region Get Method Test

        [Fact]
        public void IProductService_GetAll_NoParameter_ReturnListOfProducts()
        {
            // Arrange
            var mock = new Mock<IProductService>();
            mock.Setup(service => service.GetProducts())
                .Returns(new List<Product>());
            var productService = mock.Object;

            // Act
            var actual = productService.GetProducts();
            var expected = new List<Product>();

            // Assert
            Assert.Equal(expected,actual);
        }

        [Fact]
        public void IProductService_GetById_ParameterId_ReturnObjectProduct()
        {
            // Arrange
            var product = new Product()
            {
                Id = 1,
                Name = "Name1"
            };
            
            var mock = new Mock<IProductService>();
            mock.Setup(service => service.GetProductById(1))
                .Returns(product);
            
            var productService = mock.Object;
            
            // Act
            var actual = productService.GetProductById(1);

            // Assert
            Assert.Equal(product,actual);
        }
        

        #endregion

        #region Add Method Test

        [Fact]
        public void IProductService_Add_ParameterProduct_ReturnNewProduct()
        {
            // Arrange
            var product = new Product()
            {
                Id = 1,
                Name = "Name1"
            };
            
            var mock = new Mock<IProductService>();
            var productService = mock.Object;
            mock.Setup(service => service.CreateProduct(product))
                .Returns(product);
            
            // Act
            var actual = productService.CreateProduct(product);

            // Assert
            Assert.Equal(product,actual);
        }

        #endregion

        #region Delete Method Test

        [Fact]
        public void IProductService_Delete_ParameterId_ReturnProduct()
        {
            // Arrange
            var product = new Product()
            {
                Id = 1,
                Name = "Name1"
            };
            
            var mock = new Mock<IProductService>();
            var productService = mock.Object;
            mock.Setup(service => service.RemoveProduct(1))
                .Returns(product);
            
            // Act
            var actual = productService.RemoveProduct(1);
            
            // Assert
            Assert.Equal(product,actual);
        }

        #endregion

        #region Modify Method Test

        [Fact]
        public void IProductService_Modify_ParameterProduct_ReturnProduct()
        {
            // Arrange
            var product = new Product()
            {
                Id = 1,
                Name = "Name1"
            };

            var mock = new Mock<IProductService>();
            var productService = mock.Object;
            mock.Setup(service => service.UpdateProduct(product))
                .Returns(product);
            
            // Act
            var actual = productService.UpdateProduct(product);
            
            // Assert
            Assert.Equal(product,actual);
        }

        #endregion
    }
}