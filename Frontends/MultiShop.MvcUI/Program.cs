using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MultiShop.MvcUI.Handlers;
using MultiShop.MvcUI.Services;
using MultiShop.MvcUI.Services.Abstract;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.CategoryServices;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.CategoryServices.Abstract;
using MultiShop.MvcUI.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(JwtBearerDefaults.AuthenticationScheme,
	opt =>
	{
		opt.LoginPath = "/Login/Index/";
		opt.LogoutPath = "/Login/Logout/";
		opt.AccessDeniedPath = "/Pages/AccessDenied/";
		opt.Cookie.HttpOnly = true;
		opt.Cookie.SameSite = SameSiteMode.Strict;
		opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
		opt.Cookie.Name = "MultishopJwt";
	});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
    CookieAuthenticationDefaults.AuthenticationScheme,
    opt =>
    {
        opt.LoginPath = "/Login/Index/";
        opt.ExpireTimeSpan = TimeSpan.FromDays(5);
        opt.Cookie.Name = "MultiShopCookie";
        opt.SlidingExpiration = true;
    });

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IIdentityService, IdentityService>();
builder.Services.AddHttpClient<IUserService, UserService>(opt =>
{
    opt.BaseAddress = new Uri(builder.Configuration["IdentityUrl"]!);
}).AddHttpMessageHandler<ResourcePasswordTokenHandler>();

builder.Services.AddScoped<ResourcePasswordTokenHandler>();
builder.Services.AddScoped<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IClientCredentialTokenService, ClientCredentialTokenService>();

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddSession();
builder.Services.Configure<ClientSetting>(builder.Configuration.GetSection("ClientSettings"));
var serviceApiSettingValues = builder.Configuration.GetSection("ServiceApiSettings").Get<ServiceApiSetting>();
builder.Services.AddSingleton<ServiceApiSetting>(serviceApiSettingValues);

serviceApiSettingValues.IdentityUrl = builder.Configuration["IdentityUrl"]!;

builder.Services.AddHttpClient<ICategoryService, CategoryService>(opt =>
{
    opt.BaseAddress = new Uri($"{serviceApiSettingValues.OcelotUrl}/{serviceApiSettingValues.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddAccessTokenManagement();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Product}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
		name: "areas",
		pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
	);
});

app.Run();
