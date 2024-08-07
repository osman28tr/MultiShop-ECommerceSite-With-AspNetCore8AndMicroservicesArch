using MultiShop.MvcUI.Handlers;
using MultiShop.MvcUI.Services;
using MultiShop.MvcUI.Services.Abstract;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.CategoryServices;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.CategoryServices.Abstract;
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

            services.AddAccessTokenManagement();

            return services;
        }
    }
}
