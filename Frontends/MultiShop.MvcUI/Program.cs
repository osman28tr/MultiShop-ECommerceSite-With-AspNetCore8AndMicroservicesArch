using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MultiShop.MvcUI.Services;
using MultiShop.MvcUI.Services.Abstract;
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
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddSession();
builder.Services.Configure<ClientSetting>(builder.Configuration.GetSection("ClientSettings"));
builder.Services.Configure<ServiceApiSetting>(builder.Configuration.GetSection("ServiceApiSettings"));
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
