using Microsoft.AspNetCore.Mvc;
using team4.BLL.Dtos.Product;
using team4.BLL.Services.Product;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace team4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById(Guid id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromForm] CreateProductDto dto)
        {
            var id = await _productService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromForm] UpdateProductDto dto)
        {
            var success = await _productService.UpdateAsync(id, dto);
            if (!success)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var success = await _productService.DeleteAsync(id);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}
