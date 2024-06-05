using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Services.ProductServices.Abstract;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService categoriesService)
        {
            _productService = categoriesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var Product = await _productService.GetByIdProductAsync(id);
            return Ok(Product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDto ProductDto)
        {
            await _productService.AddAsync(ProductDto);
            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductDto ProductDto)
        {
            await _productService.UpdateAsync(ProductDto);
            return Ok("Ürün başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productService.DeleteAsync(id);
            return Ok("Ürün başarıyla silindi.");
        }
    }
}
