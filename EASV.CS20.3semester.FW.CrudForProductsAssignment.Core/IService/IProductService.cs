using System.Collections.Generic;
using EASV.CS20._3semester.FW.CrudForProductsAssignment.Core.Models;

namespace EASV.CS20._3semester.FW.CrudForProductsAssignment.Core.IService
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product GetById(int id);
        Product Add(Product product);
    }
}