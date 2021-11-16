
using System.Collections.Generic;
using System.IO;
using EASV.CS20._3semester.FW.CrudForProductsAssignment.Core.IServices;
using EASV.CS20._3semester.FW.CrudForProductsAssignment.Core.Models;
using EASV.CS20._3semester.FW.CrudForProductsAssignment.Domain.IRepositories;

namespace EASV.CS20._3semester.FW.CrudForProductsAssignment.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo ?? throw new InvalidDataException("The Repository can not be null");
        }

        public List<Product> GetProducts()
        {
            return _repo.GetProducts();
        }

        public Product CreateProduct(Product product)
        {
            return _repo.CreateProduct(product);
        }

        public Product GetProductById(int id)
        {
            return _repo.GetProductById(id);
        }

        public Product RemoveProduct(int id)
        {
            return _repo.RemoveProduct(id);
        }

        public Product UpdateProduct(Product product)
        {
            return _repo.UpdateProduct(product);
        }
    }
}