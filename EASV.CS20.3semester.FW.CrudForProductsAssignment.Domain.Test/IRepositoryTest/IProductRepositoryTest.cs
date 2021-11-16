using System.Collections.Generic;
using EASV.CS20._3semester.FW.CrudForProductsAssignment.Core.Models;
using EASV.CS20._3semester.FW.CrudForProductsAssignment.Domain.IRepository;
using Moq;
using Xunit;

namespace EASV.CS20._3semester.FW.CrudForProductsAssignment.Domain.Test.IRepositoryTest
{
    public class IProductRepositoryTest
    {
        #region IProductRepository Available

        [Fact]
        public void IProductRepository_IsAvailable()
        {
            // Arrange
            var mock = new Mock<IProductRepository>();
            
            // Assert
            Assert.NotNull(mock.Object);
        }

        #endregion


        #region CRUD

        [Fact]
        public void IProductRepository_Creat_ParameterProduct_ReturnProduct()
        {
            // Arrange
            var mock = new Mock<IProductRepository>();
            var productRepository = mock.Object;
            var product = new Product()
            {
                Id = 1,
                Name = "Name1"
            };
            mock.Setup(repository => repository.Create(product))
                .Returns(product);
            
            // Act
            var actual = productRepository.Create(product);
            
            // Assert
            Assert.Equal(product,actual);
        }
        
        [Fact]
        public void IProductRepository_ReadAll_NoParameter_ReturnListOfProduct()
        {
            // Arrange
            var mock = new Mock<IProductRepository>();
            var productRepository = mock.Object;
            var products = new List<Product>();
            mock.Setup(repository => repository.ReadAll())
                .Returns(products);
            
            // Act
            var actual = productRepository.ReadAll();
            
            // Assert
            Assert.Equal(products,actual);
        }

        [Fact]
        public void IProductRepository_ReadById_ParameterId_ReturnProduct()
        {
            // Arrange
            var mock = new Mock<IProductRepository>();
            var productRepository = mock.Object;
            var product = new Product()
            {
                Id = 1,
                Name = "Name1"
            };
            mock.Setup(repository => repository.ReadById(1))
                .Returns(product);
            
            // Act
            var actual = productRepository.ReadById(1);
            
            // Assert
            Assert.Equal(product,actual);
        }

        [Fact]
        public void IProductRepository_Update_ParameterProduct_ReturnProduct()
        {
            // Arrange
            var mock = new Mock<IProductRepository>();
            var productRepository = mock.Object;
            var product = new Product()
            {
                Id = 1,
                Name = "Name1"
            };
            mock.Setup(repository => repository.Update(product))
                .Returns(product);
            
            // Act
            var actual = productRepository.Update(product);
            
            // Assert
            Assert.Equal(product,actual);
        }
        
        [Fact]
        public void IProductRepository_Delete_ParameterProduct_ReturnProduct()
        {
            // Arrange
            var mock = new Mock<IProductRepository>();
            var productRepository = mock.Object;
            var product = new Product()
            {
                Id = 1,
                Name = "Name1"
            };
            mock.Setup(repository => repository.Delete(product))
                .Returns(product);
            
            // Act
            var actual = productRepository.Delete(product);
            
            // Assert
            Assert.Equal(product,actual);
        }



        #endregion
    }
}