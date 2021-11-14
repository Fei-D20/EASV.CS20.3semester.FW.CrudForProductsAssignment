using EASV.CS20._3semester.FW.CrudForProductsAssignment.Core.Models;
using Xunit;

namespace EASV.CS20._3semester.FW.CrudForProductsAssignment.Core.Test
{
    public class ProductTest
    {
        private readonly Product _product;

        public ProductTest()
        {
            _product = new Product();
        }

        [Fact]
        public void CanBeInitialized()
        {
            Assert.NotNull(_product);
        }

        [Fact]
        public void SetIdTest()
        {
            _product.Id = 1;
            Assert.Equal(1, _product.Id);
            Assert.True(_product.Id is int);
        }
        
        [Fact]
        public void SetNameTest()
        {
            _product.Name = "test";
            Assert.Equal("test", _product.Name);
            Assert.True(_product.Name is string);
        }
    }
}