using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.ProductImageServices.Abstract;
using Newtonsoft.Json;

namespace MultiShop.MvcUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailImageSliderComponentPartial : ViewComponent
    {
        private readonly IProductImageService _productImageService;
        public _ProductDetailImageSliderComponentPartial(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string productId)
        {
            var values = await _productImageService.GetAllByProductAsync(productId);
            if (values != null)
                return View(values);
            return View();
        }
    }
}
