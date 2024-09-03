using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using api.Data;
using api.DTOs.Product;
using api.Mappers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace api.Controllers.DTO
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {   
        private readonly ApplicationDBContext _context;
        public ProductController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllProducts()
        {
            var AllProducts = await _context.Products.ToListAsync();
            
            var AllUDTO = AllProducts.Select(s => s.ToProductDTO());

            return Ok(AllProducts);
        }

        [HttpGet]
        [Route("GetProductByID/{id}")]
        public async Task<IActionResult> GetProductByID( int id)
        {
            var Product = await _context.Products.FindAsync(id);
            if(Product == null)
            {
                return NotFound();
            }

            return Ok(Product.ToProductDTO());
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequestDTO ProductDTO)
        {
            var ProductModel = ProductDTO.ToProductFromCreateDTO();
            await _context.Products.AddAsync(ProductModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProductByID), new {id = ProductModel.Pid}, ProductModel.ToProductDTO());
        }

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> UpdateProduct( [FromBody] UpdateProductRequestDTO UpdateDTO)
        {
            var ProductModel = await _context.Products.FirstOrDefaultAsync(t => t.Pid == UpdateDTO.price);
            if(ProductModel == null)
            {
                return NotFound();
            }

            ProductModel.productName = UpdateDTO.productName;
            ProductModel.productName = UpdateDTO.productName;
            ProductModel.productName = UpdateDTO.productName;

            await _context.SaveChangesAsync();

            return Ok(ProductModel.ToProductDTO());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            var ProductModel = await _context.Products.FirstOrDefaultAsync(t => t.Pid == id);
            if(ProductModel == null)
            {
                return NotFound();
            }

            _context.Products.Remove(ProductModel);
            await _context.SaveChangesAsync();
            
            return NoContent();
        }
    }
}