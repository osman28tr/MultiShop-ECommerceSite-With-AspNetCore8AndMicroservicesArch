using MultiShop.MvcUI.Handlers;
using MultiShop.MvcUI.Services;
using MultiShop.MvcUI.Services.Abstract;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.AboutServices;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.AboutServices.Abstract;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.CategoryServices;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.CategoryServices.Abstract;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.ContactServices;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.ContactServices.Abstract;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.CustomerServices;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.CustomerServices.Abstract;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.FeatureServices;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.FeatureServices.Abstract;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.FeatureSliderServices;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.FeatureSliderServices.Abstract;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.OfferDiscountServices;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.OfferDiscountServices.Abstract;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.ProductDetailDetailServices;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.ProductDetailServices.Abstract;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.ProductImageServices;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.ProductImageServices.Abstract;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.ProductServices;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.ProductServices.Abstract;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.SpecialOfferServices;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.SpecialOfferServices.Abstract;
using MultiShop.MvcUI.Services.Repositories.CommentServices;
using MultiShop.MvcUI.Services.Repositories.CommentServices.Abstract;
using MultiShop.MvcUI.Settings;

namespace MultiShop.MvcUI.Extensions
{
    public static class MultiShopUIServicesRegistration
    {
        public static IServiceCollection AddMultiShopUIServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddHttpContextAccessor();

            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddHttpClient<IUserService, UserService>(opt =>
            {
                opt.BaseAddress = new Uri(configuration["IdentityUrl"]!);
            }).AddHttpMessageHandler<ResourcePasswordTokenHandler>();

            services.AddScoped<ResourcePasswordTokenHandler>();
            services.AddScoped<ClientCredentialTokenHandler>();

            services.AddHttpClient<IClientCredentialTokenService, ClientCredentialTokenService>();

            services.AddHttpClient();
            services.AddSession();
            services.Configure<ClientSetting>(configuration.GetSection("ClientSettings"));
            var serviceApiSettingValues = configuration.GetSection("ServiceApiSettings").Get<ServiceApiSetting>();
            services.AddSingleton<ServiceApiSetting>(serviceApiSettingValues);

            serviceApiSettingValues.IdentityUrl = configuration["IdentityUrl"]!;

            services.AddHttpClient<ICategoryService, CategoryService>(opt =>
            {
                opt.BaseAddress = new Uri($"{serviceApiSettingValues.OcelotUrl}/{serviceApiSettingValues.Catalog.Path}");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<IProductService, ProductService>(opt =>
            {
                opt.BaseAddress = new Uri($"{serviceApiSettingValues.OcelotUrl}/{serviceApiSettingValues.Catalog.Path}");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<ISpecialOfferService, SpecialOfferService>(opt =>
            {
                opt.BaseAddress = new Uri($"{serviceApiSettingValues.OcelotUrl}/{serviceApiSettingValues.Catalog.Path}");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<IFeatureSliderService, FeatureSliderService>(opt =>
            {
                opt.BaseAddress = new Uri($"{serviceApiSettingValues.OcelotUrl}/{serviceApiSettingValues.Catalog.Path}");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<IFeatureService, FeatureService>(opt =>
            {
                opt.BaseAddress = new Uri($"{serviceApiSettingValues.OcelotUrl}/{serviceApiSettingValues.Catalog.Path}");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<IOfferDiscountService, OfferDiscountService>(opt =>
            {
                opt.BaseAddress = new Uri($"{serviceApiSettingValues.OcelotUrl}/{serviceApiSettingValues.Catalog.Path}");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<ICustomerService, CustomerService>(opt =>
            {
                opt.BaseAddress = new Uri($"{serviceApiSettingValues.OcelotUrl}/{serviceApiSettingValues.Catalog.Path}");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<IAboutService, AboutService>(opt =>
            {
                opt.BaseAddress = new Uri($"{serviceApiSettingValues.OcelotUrl}/{serviceApiSettingValues.Catalog.Path}");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<IProductDetailService, ProductDetailService>(opt =>
            {
                opt.BaseAddress = new Uri($"{serviceApiSettingValues.OcelotUrl}/{serviceApiSettingValues.Catalog.Path}");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<IProductImageService, ProductImageService>(opt =>
            {
                opt.BaseAddress = new Uri($"{serviceApiSettingValues.OcelotUrl}/{serviceApiSettingValues.Catalog.Path}");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<IContactService, ContactService>(opt =>
            {
                opt.BaseAddress = new Uri($"{serviceApiSettingValues.OcelotUrl}/{serviceApiSettingValues.Catalog.Path}");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<IReviewService, ReviewService>(opt =>
            {
                opt.BaseAddress = new Uri($"{serviceApiSettingValues.OcelotUrl}/{serviceApiSettingValues.Comment.Path}");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddAccessTokenManagement();

            return services;
        }
    }
}
