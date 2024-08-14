using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CustomerDtos;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.CustomerServices.Abstract;
using Newtonsoft.Json;

namespace MultiShop.MvcUI.ViewComponents.DefaultViewComponents
{
    public class _CustomersDefaultComponentPartial : ViewComponent
    {
        private readonly ICustomerService _customerService;
        public _CustomersDefaultComponentPartial(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _customerService.GetAllAsync();
            if (values != null)
                return View(values);
            return View();
        }
    }
}
