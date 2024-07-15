using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using MultiShop.Catalog.Contexts;
using MultiShop.Catalog.Extensions;
using MultiShop.Catalog.Services.CategoryServices;
using MultiShop.Catalog.Services.CategoryServices.Abstract;
using MultiShop.Catalog.Services.FeatureServices;
using MultiShop.Catalog.Services.FeatureServices.Abstract;
using MultiShop.Catalog.Services.FeatureSliderServices;
using MultiShop.Catalog.Services.FeatureSliderServices.Abstract;
using MultiShop.Catalog.Services.OfferDiscountServices;
using MultiShop.Catalog.Services.OfferDiscountServices.Abstract;
using MultiShop.Catalog.Services.ProductDetailServices;
using MultiShop.Catalog.Services.ProductDetailServices.Abstract;
using MultiShop.Catalog.Services.ProductImageServices;
using MultiShop.Catalog.Services.ProductImageServices.Abtract;
using MultiShop.Catalog.Services.ProductServices;
using MultiShop.Catalog.Services.ProductServices.Abstract;
using MultiShop.Catalog.Services.SpecialOfferServices;
using MultiShop.Catalog.Services.SpecialOfferServices.Abstract;
using MultiShop.Catalog.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.Audience = "MultiShopCatalog";
    opt.RequireHttpsMetadata = false;
});

builder.Services.AddControllers();
builder.Services.AddCatalogAPIServices();

builder.Services.Configure<DatabaseSetting>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddScoped<IDatabaseSetting>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSetting>>().Value;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
