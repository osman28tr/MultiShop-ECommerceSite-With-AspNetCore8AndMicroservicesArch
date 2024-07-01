using Microsoft.AspNetCore.Mvc;

namespace MultiShop.MvcUI.ViewComponents.ProductViewComponents
{
    public class _ProductListByColorFilterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
