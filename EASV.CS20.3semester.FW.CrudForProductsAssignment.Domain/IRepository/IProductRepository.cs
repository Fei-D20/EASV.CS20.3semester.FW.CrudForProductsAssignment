using System.Collections.Generic;
using EASV.CS20._3semester.FW.CrudForProductsAssignment.Core.Models;

namespace EASV.CS20._3semester.FW.CrudForProductsAssignment.Domain.IRepository
{
    public interface IProductRepository
    {
        Product Create(Product product);
        List<Product> ReadAll();
        Product ReadById(int id);
        Product Update(Product product);
        Product Delete(Product product);
    }
}