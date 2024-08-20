using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.OrderDtos;

namespace MultiShop.MvcUI.ViewComponents.OrderViewComponents
{
    public class _OrderBillingAddressComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke(CreateOrderAddressDto createOrderAddressDto)
        {
            return View(createOrderAddressDto);
        }
    }
}
