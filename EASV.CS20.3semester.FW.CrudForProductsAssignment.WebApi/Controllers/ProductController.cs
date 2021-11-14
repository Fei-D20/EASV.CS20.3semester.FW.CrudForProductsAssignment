using System;
using System.Linq;
using EASV.CS20._3semester.FW.CrudForProductsAssignment.Core.IServices;
using EASV.CS20._3semester.FW.CrudForProductsAssignment.Core.Models;
using EASV.CS20._3semester.FW.CrudForProductsAssignment.WebApi.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EASV.CS20._3semester.FW.CrudForProductsAssignment.WebApi.Controllers{
    
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService productService)
        {
            _service = productService;
        }

        [HttpGet]
        public ActionResult<ProductDto> GetAllProducts()
        {
            try
            {
                var list = _service.GetProducts();
                return Ok(new GetProductsDto
                {
                    Products = list.Select(product => new ProductDto
                    {
                        Id = product.Id,
                        Name = product.Name
                    }).ToList()
                });
            }
            catch(Exception e)
            {
                return StatusCode(500, "System problems occured");
            }
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