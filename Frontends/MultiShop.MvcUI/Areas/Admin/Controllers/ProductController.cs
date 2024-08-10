using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;
using System.Text;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.CategoryServices.Abstract;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.ProductServices.Abstract;

namespace MultiShop.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Product")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewbagProduct("Ürün Listesi");
            var values = await _productService.GetAllAsync();
            return View(values);
        }
        [Route("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            ViewbagProduct("Ürün Listesi");
            var values = await _productService.GetListProductWithCategory();
            return View(values);
        }
        [HttpGet]
        [Route("Create")]
        public async Task<IActionResult> Create()
        {
            ViewbagProduct("Ürün Ekleme");
            var values = await _categoryService.GetAllAsync();
            List<SelectListItem> categoryList = (from x in values
                select new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id
                }).ToList();
            ViewBag.CategoryList = categoryList;
            return View();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(CreateProductDto createProductDto)
        {
            await _productService.AddAsync(createProductDto);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }
        [Route("Update/{id}")]
        public async Task<IActionResult> Update(string id)
        {
            ViewbagProduct("Ürün Güncelleme");
            var values = await _productService.GetByIdProductAsync(id);
            var categoryValues = await _categoryService.GetAllAsync();
            List<SelectListItem> categoryList = (from x in categoryValues
                                                 select new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id
                }).ToList();
            ViewBag.CategoryList = categoryList;
            return View(values);
        }
        [HttpPost]
        [Route("Update/{id}")]
        public async Task<IActionResult> Update(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateAsync(updateProductDto);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productService.DeleteAsync(id);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }
        void ViewbagProduct(string headPage)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = headPage;
            ViewBag.v4 = "Ürün İşlemleri";
        }
    }
}
