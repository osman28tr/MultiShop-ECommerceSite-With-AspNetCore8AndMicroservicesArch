using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Application;
using MultiShop.Order.Application.Features.CQRS.Handlers.CommandHandlers.AddressCommandHandlers;
using MultiShop.Order.Application.Features.CQRS.Handlers.CommandHandlers.OrderDetailCommandHandlers;
using MultiShop.Order.Application.Features.CQRS.Handlers.QueryHandlers.AddressQueryHandlers;
using MultiShop.Order.Application.Features.CQRS.Handlers.QueryHandlers.OrderDetailQueryHandlers;
using MultiShop.Order.Persistance;
using MultiShop.Order.Persistance.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.Audience = "MultiShopOrder";
    opt.RequireHttpsMetadata = false;
});
builder.Services.AddControllers();
builder.Services.AddDbContext<MultiShopOrderContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("MSSQL")));
#region CQRSNotMediator
builder.Services.AddScoped<GetAddressByIdQueryHandler>();
builder.Services.AddScoped<GetListAddressQueryHandler>();
builder.Services.AddScoped<CreateAddressCommandHandler>();
builder.Services.AddScoped<UpdateAddressCommandHandler>();
builder.Services.AddScoped<DeleteAddressCommandHandler>();

builder.Services.AddScoped<GetListOrderDetailQueryHandler>();
builder.Services.AddScoped<GetOrderDetailByIdQueryHandler>();
builder.Services.AddScoped<CreateOrderDetailCommandHandler>();
builder.Services.AddScoped<UpdateOrderDetailCommandHandler>();
builder.Services.AddScoped<DeleteOrderDetailCommandHandler>();
#endregion

builder.Services.AddPersistanceServices();
builder.Services.AddApplicationServices();

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
