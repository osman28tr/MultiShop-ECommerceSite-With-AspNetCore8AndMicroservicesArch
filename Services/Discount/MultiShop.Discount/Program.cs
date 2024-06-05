using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using MultiShop.Discount.Contexts.Dapper;
using MultiShop.Discount.Contexts.EntityFramework;
using MultiShop.Discount.Services;
using MultiShop.Discount.Services.Abstract;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.Audience = "MultiShopDiscount";
    opt.RequireHttpsMetadata = false;
});
builder.Services.AddControllers();
builder.Services.AddDbContext<MultiShopDiscountContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MSSQL"));
});
builder.Services.AddScoped<MultiShopDiscountDapperContext>();
builder.Services.AddScoped<IDiscountService, DiscountService>();
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
