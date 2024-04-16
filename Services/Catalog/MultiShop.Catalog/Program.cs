using System.Reflection;
using Microsoft.Extensions.Options;
using MultiShop.Catalog.Contexts;
using MultiShop.Catalog.Services.CategoryServices;
using MultiShop.Catalog.Services.CategoryServices.Abstract;
using MultiShop.Catalog.Services.ProductDetailServices;
using MultiShop.Catalog.Services.ProductDetailServices.Abstract;
using MultiShop.Catalog.Services.ProductImageServices;
using MultiShop.Catalog.Services.ProductImageServices.Abtract;
using MultiShop.Catalog.Services.ProductServices;
using MultiShop.Catalog.Services.ProductServices.Abstract;
using MultiShop.Catalog.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<MultiShopCatalogContext>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
