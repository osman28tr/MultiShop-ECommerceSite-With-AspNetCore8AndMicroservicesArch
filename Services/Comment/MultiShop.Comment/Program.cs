using Microsoft.Extensions.Options;
using MultiShop.Comment.Extensions;
using MultiShop.Comment.Repositories;
using MultiShop.Comment.Repositories.Abstract;
using MultiShop.Comment.Services;
using MultiShop.Comment.Services.Abstract;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAuthentication().AddJwtBearer("OcelotAuthenticationScheme", opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.Audience = "MultiShopComment";
    opt.RequireHttpsMetadata = false;
});
builder.Services.AddElastic(builder.Configuration);
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IReviewService, ReviewService>();
//ignore reference loop

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
