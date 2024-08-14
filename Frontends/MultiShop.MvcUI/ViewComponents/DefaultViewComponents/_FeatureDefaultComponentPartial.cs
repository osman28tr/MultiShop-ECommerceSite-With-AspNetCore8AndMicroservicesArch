using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.FeatureServices.Abstract;
using Newtonsoft.Json;

namespace MultiShop.MvcUI.ViewComponents.DefaultViewComponents
{
    public class _FeatureDefaultComponentPartial : ViewComponent
    {
        private readonly IFeatureService _featureService;
        public _FeatureDefaultComponentPartial(IFeatureService featureService)
        {
            _featureService = featureService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _featureService.GetAllAsync();
            if(values != null)
                return View(values);
            return View();
        }
    }
}
