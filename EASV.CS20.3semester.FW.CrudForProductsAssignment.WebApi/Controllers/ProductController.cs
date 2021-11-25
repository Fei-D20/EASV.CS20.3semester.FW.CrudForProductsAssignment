using System;
using System.Collections.Generic;
using System.Linq;
using EASV.CS20._3semester.FW.CrudForProductsAssignment.Core.IServices;
using EASV.CS20._3semester.FW.CrudForProductsAssignment.Core.Models;
using EASV.CS20._3semester.FW.CrudForProductsAssignment.WebApi.Dtos;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

namespace EASV.CS20._3semester.FW.CrudForProductsAssignment.WebApi.Controllers{
    
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService productService)
        {
            _service = productService;
        }

        // [HttpGet]
        // public ActionResult<List<ProductDto>> GetAllProducts()
        // {
        //     // her i change the ActionResult<List<ProductDto>> as Product Array to try to let my frontend show all 
        //     // product. this is temporary. and i will change it back later.  
        //     
        //     try  
        //     {
        //         var list = _service.GetProducts(); 
        //         return Ok(new GetProductsDto
        //         {
        //             Products = list
        //                 .Select(product => new ProductDto
        //                 {
        //                     Id = product.Id,
        //                     Name = product.Name
        //                 })
        //                 .ToList()
        //         });
        //     }
        //     catch(Exception e)
        //     {
        //         return StatusCode(500, "System problems occured");
        //     }
        // }

        [HttpGet]
        public ProductDto[] GetAllProduct_ReturnArray()
        {
            var products = _service.GetProducts();
            var productDtos = new List<ProductDto>();
            foreach (var product in products)
            {
                productDtos.Add(new ProductDto()
                {
                    Id = product.Id,
                    Name = product.Name
                });
            }   
            return productDtos.ToArray();
        }

        [HttpGet("{id}")]
        public Product GetById(int id)
        {
            return _service.GetProductById(id);
        }

        [HttpPost]
        public ActionResult<Product> CreateProduct([FromBody] ProductDto dto)
        {
            try
            {
                var product = new Product
                {
                    Id = dto.Id,
                    Name = dto.Name
                };
                return Ok($"Product{_service.CreateProduct(product)} created...");
            }
            catch (ArgumentException argumentException)
            {
                return BadRequest(argumentException.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        { 
            _service.RemoveProduct(id);
        }

        [HttpPut]
        public void UpdateProduct(Product product)
        { 
            _service.UpdateProduct(product);
        }

    }
}