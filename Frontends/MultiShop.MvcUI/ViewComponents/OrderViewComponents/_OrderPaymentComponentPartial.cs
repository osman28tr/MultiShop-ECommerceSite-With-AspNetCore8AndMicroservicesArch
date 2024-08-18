using Microsoft.AspNetCore.Mvc;

namespace MultiShop.MvcUI.ViewComponents.OrderViewComponents
{
    public class _OrderPaymentComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
