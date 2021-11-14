using System.Collections.Generic;
using EASV.CS20._3semester.FW.CrudForProductsAssignment.Core.IServices;
using EASV.CS20._3semester.FW.CrudForProductsAssignment.Core.Models;
using Moq;
using Xunit;

namespace EASV.CS20._3semester.FW.CrudForProductsAssignment.Core.Test
{
    public class IProductServiceTest
    {
        private readonly Mock<IProductService> _mock;
        private readonly IProductService _service;

        public IProductServiceTest()
        {
            _mock = new Mock<IProductService>();
            _service = _mock.Object;
        }

        [Fact]
        public void IProductService_IsAvilable()
        {
            Assert.NotNull(_mock);
        }

        [Fact]
        public void IProductService_GetProducts()
        {
            var fakeList = new List<Product>();
            _mock.Setup(s => s.GetProducts()).Returns(new List<Product>());
            Assert.Equal(fakeList, _service.GetProducts());
        }

        [Fact]
        public void IProductService_GetProductById()
        {
            var id = 1;
            var fakeProduct = new Product();
            _mock.Setup(s => s.GetProductById(id)).Returns(new Product {Id = 1});
            Assert.True(_service.GetProductById(id) is Product);
        }

        [Fact]
        public void IProductService_RemoveProduct()
        {
            
        }
    }
}
  