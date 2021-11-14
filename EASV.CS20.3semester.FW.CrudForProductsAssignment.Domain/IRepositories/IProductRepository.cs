using System.Collections.Generic;
using EASV.CS20._3semester.FW.CrudForProductsAssignment.Core.Models;

namespace EASV.CS20._3semester.FW.CrudForProductsAssignment.Domain.IRepositories
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        Product CreateProduct(Product product);
        Product GetProductById(int id);
        Product RemoveProduct(int id);
        Product UpdateProduct(Product product);
    }
}