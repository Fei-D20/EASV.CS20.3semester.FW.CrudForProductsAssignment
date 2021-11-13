using System.Collections.Generic;
using System.IO;
using EASV.CS20._3semester.FW.CrudForProductsAssignment.Core.IService;
using EASV.CS20._3semester.FW.CrudForProductsAssignment.Core.Models;
using EASV.CS20._3semester.FW.CrudForProductsAssignment.Domain.IRepository;

namespace EASV.CS20._3semester.FW.CrudForProductsAssignment.Domain.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            if (_productRepository == null)
                throw new InvalidDataException("The Repository can not be null"); 
        }

        public List<Product> GetAll()
        {
            return _productRepository.ReadAll();
        }

        public Product GetById(int id)
        {
            return _productRepository.ReadById(id);
        }

        public Product Add(Product product)
        {
            return _productRepository.Create(product);
        }

        public Product Delete(int id)
        {
            var byId = GetById(id);
            return _productRepository.Delete(byId);
        }

        public Product Modify(Product product)
        {
            return _productRepository.Update(product);
        }
    }
}