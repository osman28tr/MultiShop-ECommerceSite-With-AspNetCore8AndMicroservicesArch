using Microsoft.AspNetCore.Mvc;

namespace MultiShop.MvcUI.ViewComponents.BasketViewComponents
{
    public class _BasketCheckOutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke(decimal totalPrice)
        {
            ViewBag.TotalPrice = totalPrice;
            return View();
        }
    }
}
