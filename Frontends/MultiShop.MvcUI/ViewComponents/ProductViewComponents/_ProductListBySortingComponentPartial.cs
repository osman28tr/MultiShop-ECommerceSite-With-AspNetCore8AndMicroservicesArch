using Microsoft.AspNetCore.Mvc;

namespace MultiShop.MvcUI.ViewComponents.ProductViewComponents
{
    public class _ProductListBySortingComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
