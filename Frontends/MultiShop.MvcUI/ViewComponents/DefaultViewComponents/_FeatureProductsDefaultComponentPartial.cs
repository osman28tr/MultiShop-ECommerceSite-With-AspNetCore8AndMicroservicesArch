using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.ProductServices.Abstract;
using Newtonsoft.Json;

namespace MultiShop.MvcUI.ViewComponents.DefaultViewComponents
{
    public class _FeatureProductsDefaultComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;
        public _FeatureProductsDefaultComponentPartial(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _productService.GetAllAsync();
            if (values != null)
                return View(values);
            return View();
        }
    }
}
