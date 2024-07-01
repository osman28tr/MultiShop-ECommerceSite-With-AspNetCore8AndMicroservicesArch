using Microsoft.AspNetCore.Mvc;

namespace MultiShop.MvcUI.ViewComponents.ProductViewComponents
{
    public class _ProductListPaginationComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
