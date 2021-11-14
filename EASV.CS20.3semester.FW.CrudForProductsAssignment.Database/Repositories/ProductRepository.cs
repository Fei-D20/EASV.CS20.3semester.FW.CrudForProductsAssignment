using System.Collections.Generic;
using System.Linq;
using EASV.CS20._3semester.FW.CrudForProductsAssignment.Core.Models;
using EASV.CS20._3semester.FW.CrudForProductsAssignment.Database.Entities;
using EASV.CS20._3semester.FW.CrudForProductsAssignment.Domain.IRepositories;

namespace EASV.CS20._3semester.FW.CrudForProductsAssignment.Database
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext _ctx;
        private List<ProductEntity> _pets = new List<ProductEntity>();
        int _id = 1;

        public ProductRepository(ApplicationContext ctx)
        {
            _ctx = ctx;
        }

        public List<Product> GetProducts()
        {
            var selectQuery = _ctx.Products.Select(productEntity => new Product
            {
                Id = productEntity.Id,
                Name = productEntity.Name
            });
            return selectQuery.ToList();
        }

        public Product CreateProduct(Product product)
        {
            ProductEntity productEntity = new ProductEntity
            {
                Id = product.Id,
                Name = product.Name
            };
            _ctx.Products.Add(productEntity);
            _ctx.SaveChanges();
            return product;
        }

        public Product GetProductById(int id)
        {
            return _ctx.Products.Select(productEntity => new Product
            {
                Id = productEntity.Id,
                Name = productEntity.Name
            }).FirstOrDefault(p => p.Id == id);
        }

        public Product RemoveProduct(int id)
        {
            var entity = _ctx.Products.Remove(new ProductEntity {Id = id}).Entity;
            _ctx.SaveChanges();
            return new Product
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public Product UpdateProduct(Product product)
        {
            var entity = new ProductEntity
            {
                Id = product.Id,
                Name = product.Name
            };
            _ctx.Products.Update(entity);
            _ctx.SaveChanges();
            return product;
        }
    }
}