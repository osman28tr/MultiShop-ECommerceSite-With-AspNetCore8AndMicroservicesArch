using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Services.ProductDetailServices.Abstract;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailService _productDetailService;
        public ProductDetailsController(IProductDetailService categoriesService)
        {
            _productDetailService = categoriesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var productDetails = await _productDetailService.GetAllAsync();
            return Ok(productDetails);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var productDetail = await _productDetailService.GetByIdProductDetailAsync(id);
            return Ok(productDetail);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDetailDto productDetailDto)
        {
            await _productDetailService.AddAsync(productDetailDto);
            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductDetailDto ProductDetailDto)
        {
            await _productDetailService.UpdateAsync(ProductDetailDto);
            return Ok("Ürün Detayı başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productDetailService.DeleteAsync(id);
            return Ok("Ürün Detayı başarıyla silindi.");
        }
    }
}
