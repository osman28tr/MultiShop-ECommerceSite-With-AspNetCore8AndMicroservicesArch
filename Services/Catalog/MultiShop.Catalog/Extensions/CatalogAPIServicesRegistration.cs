using MultiShop.Catalog.Contexts;
using MultiShop.Catalog.Services.CategoryServices.Abstract;
using MultiShop.Catalog.Services.CategoryServices;
using MultiShop.Catalog.Services.FeatureServices.Abstract;
using MultiShop.Catalog.Services.FeatureServices;
using MultiShop.Catalog.Services.FeatureSliderServices.Abstract;
using MultiShop.Catalog.Services.FeatureSliderServices;
using MultiShop.Catalog.Services.OfferDiscountServices.Abstract;
using MultiShop.Catalog.Services.OfferDiscountServices;
using MultiShop.Catalog.Services.ProductDetailServices.Abstract;
using MultiShop.Catalog.Services.ProductDetailServices;
using MultiShop.Catalog.Services.ProductImageServices.Abtract;
using MultiShop.Catalog.Services.ProductImageServices;
using MultiShop.Catalog.Services.ProductServices.Abstract;
using MultiShop.Catalog.Services.ProductServices;
using MultiShop.Catalog.Services.SpecialOfferServices.Abstract;
using MultiShop.Catalog.Services.SpecialOfferServices;
using System.Reflection;
using Microsoft.Extensions.Options;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Extensions
{
    public static class CatalogAPIServicesRegistration
    {
        public static IServiceCollection AddCatalogAPIServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<MultiShopCatalogContext>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductDetailService, ProductDetailService>();
            services.AddScoped<IProductImageService, ProductImageService>();
            services.AddScoped<IFeatureSliderService, FeatureSliderService>();
            services.AddScoped<ISpecialOfferService, SpecialOfferService>();
            services.AddScoped<IFeatureService, FeatureService>();
            services.AddScoped<IOfferDiscountService, OfferDiscountService>();

            services.Configure<DatabaseSetting>(configuration.GetSection("DatabaseSettings"));
            services.AddScoped<IDatabaseSetting>(sp =>
            {
                return sp.GetRequiredService<IOptions<DatabaseSetting>>().Value;
            });

            return services;
        }
    }
}
