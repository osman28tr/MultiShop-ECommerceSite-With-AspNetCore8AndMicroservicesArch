using Microsoft.AspNetCore.Mvc;

namespace MultiShop.MvcUI.ViewComponents.ProductViewComponents
{
    public class _ProductListByFilterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
