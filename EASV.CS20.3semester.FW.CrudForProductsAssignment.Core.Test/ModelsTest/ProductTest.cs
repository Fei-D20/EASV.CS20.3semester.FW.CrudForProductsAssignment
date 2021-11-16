using EASV.CS20._3semester.FW.CrudForProductsAssignment.Core.Models;
using Xunit;

namespace EASV.CS20._3semester.FW.CrudForProductsAssignment.Core.Test.ModelsTest
{
    public class ProductTest
    {
        #region Product

        /// <summary>
        /// Initialize the new model and test it is not null
        /// </summary>
        [Fact]
        public void Product_CanBeInitialize()
        {
            // Arrange
            var product = new Product();
            
            // Assert
            Assert.NotNull(product);
        }
        
        #endregion

        #region Product Id

        /// <summary>
        /// Test the property Id is exist and can be set a value, can get a correct value.
        /// </summary>
        [Fact]
        public void Product_Id_SetId_GetId()
        {
            // Arrange
            var product = new Product
            {
                // Act
                Id = 1
            };

            // Assert
            Assert.Equal(1,product.Id);
        }

        /// <summary>
        /// Test the property Id type is Integer
        /// </summary>
        [Fact]
        public void Product_Id_ShouldBeInt()
        {
            // Arrange
            var product = new Product();
            
            // Assert
            Assert.True(product.Id is int);
        }

        #endregion
        
        #region Product Name

        [Fact]
        public void Product_Name_SetName_GetName()
        {
            // Arrange
            var product = new Product
            {
                // Act
                Name = "Name1"
            };

            // Assert
            Assert.Equal("Name1",product.Name);
        }

        [Fact]
        public void Product_Name_ShouldBeString()
        {
            // Arrange
            var product = new Product();
            
            // Act
            product.Name = "Name1";
            // Assert
            Assert.True(product.Name is string);
        }

        #endregion
        
    }
}