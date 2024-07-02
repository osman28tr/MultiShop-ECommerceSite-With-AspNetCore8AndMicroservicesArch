using Microsoft.AspNetCore.Mvc;

namespace MultiShop.MvcUI.ViewComponents.BasketViewComponents
{
    public class _BasketCheckOutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
