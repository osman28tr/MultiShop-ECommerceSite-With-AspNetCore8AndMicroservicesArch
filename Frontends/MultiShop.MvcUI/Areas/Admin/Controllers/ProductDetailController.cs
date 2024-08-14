using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using Newtonsoft.Json;
using System.Text;
using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.ProductDetailServices.Abstract;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.ProductImageServices.Abstract;

namespace MultiShop.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/ProductDetail")]
    public class ProductDetailController : Controller
    {
        private readonly IProductImageService _productImageService;
        private readonly IProductDetailService _productDetailService;
        public ProductDetailController(IProductImageService productImageService, IProductDetailService productDetailService)
        {
            _productImageService = productImageService;
            _productDetailService = productDetailService;
        }
        [HttpGet]
        [Route("Index/{productId}")]
        public async Task<IActionResult> Index(string productId)
        {
            ViewbagProductDetail("Ürün Açıklama Sayfası");
            ViewBag.ProductId = productId;
            var values = await _productDetailService.GetByProductAsync(productId);
            if(values != null)
                return View(values);
            return View();
        }
        [HttpPost]
        [Route("Index/{productId}")]
        public async Task<IActionResult> Index(ResultProductDetailDto resultProductDetailDto)
        {
            UpdateProductDetailDto updateProductDetailDto = new()
            {
                Id = resultProductDetailDto.Id,
                Description = resultProductDetailDto.Description,
                Info = resultProductDetailDto.Info,
                ProductId = resultProductDetailDto.ProductId
            };
            await _productDetailService.UpdateAsync(updateProductDetailDto);
            return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
        }

        [HttpGet]
        [Route("Create/{productId}")]
        public IActionResult Create(string productId)
        {
            ViewBag.ProductId = productId;
            return View();
        }
        [HttpPost]
        [Route("Create/{productId}")]
        public async Task<IActionResult> Create(string productId, CreateProductDetailDto createProductDetailDto)
        {
            createProductDetailDto.ProductId = productId;
            await _productDetailService.AddAsync(createProductDetailDto);
            return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
        }
        //[HttpGet]
        //[Route("ProductDetailImage/{productId}")]
        //public async Task<IActionResult> ProductDetailImage(string productId)
        //{
        //    ViewbagProductDetail("Ürün Görsel Güncelleme Sayfası");
        //    var values = await _productImageService.GetAllByProductAsync(productId);
        //    if (values != null)
        //        return View(values);
        //    return View();
        //}
        //[HttpPost]
        //[Route("ProductDetailImage/{productId}")]
        //public async Task<IActionResult> ProductDetailImage(ResultProductImageDto updateProductImageDto)
        //{
        //    var jsonData = JsonConvert.SerializeObject(updateProductImageDto);
        //    var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //    var responseMessage = await _httpClient.PutAsync(_catalogProductImagesUrl, stringContent);
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
        //    }
        //    return View();
        //}

        void ViewbagProductDetail(string headPage)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Ürün Açıklamaları";
            ViewBag.v3 = headPage;
            ViewBag.v4 = "Ürün Açıklama İşlemleri";
        }
    }
}
