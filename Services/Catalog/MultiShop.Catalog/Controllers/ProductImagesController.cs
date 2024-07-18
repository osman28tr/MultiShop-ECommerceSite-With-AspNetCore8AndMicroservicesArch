using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Services.ProductImageServices.Abtract;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService _productImageService;
        public ProductImagesController(IProductImageService categoriesService)
        {
            _productImageService = categoriesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var productImages = await _productImageService.GetAllAsync();
            return Ok(productImages);
        }

        [HttpGet("GetListByProductId/{productId}")]
        public async Task<IActionResult> GetListByProductId(string productId)
        {
            var productImages = await _productImageService.GetAllByProductAsync(productId);
            return Ok(productImages);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var productImage = await _productImageService.GetByIdProductImageAsync(id);
            return Ok(productImage);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductImageDto productImageDto)
        {
            await _productImageService.AddAsync(productImageDto);
            return Created();
        }

        //[HttpPut]
        //public async Task<IActionResult> Update([FromBody] UpdateProductImageDto productImageDto)
        //{
        //    await _productImageService.UpdateAsync(productImageDto);
        //    return Ok("Ürün Resmi başarıyla güncellendi.");
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productImageService.DeleteAsync(id);
            return Ok("Ürün Resmi başarıyla silindi.");
        }
    }
}
