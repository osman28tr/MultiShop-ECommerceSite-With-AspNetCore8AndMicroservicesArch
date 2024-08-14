using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.FeatureSliderServices.Abstract;
using Newtonsoft.Json;

namespace MultiShop.MvcUI.ViewComponents.DefaultViewComponents
{
    public class _CarouselDefaultComponentPartial : ViewComponent
    {
        private readonly IFeatureSliderService _featureSliderService;
        public _CarouselDefaultComponentPartial(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _featureSliderService.GetAllAsync();
            if (values != null)
                return View(values);
            return View();
        }
    }
}
