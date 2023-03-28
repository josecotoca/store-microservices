using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Store.Api.ShopinCart.Persistence;
using Store.Api.ShopinCart.Persistence.Repositories;
using Store.Api.ShopinCart.Persistence.Repositories.Base;
using Store.Api.ShopinCart.Remote;
using Store.Api.ShopinCart.Remote.Interface;
using Store.Api.ShopinCart.Services.Commands;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddControllers().AddFluentValidation(
    cfg => cfg.RegisterValidatorsFromAssemblyContaining<CommandCreateSale>()
    );

builder.Services.AddDbContext<ContextCart>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("ConexionDbCart"));
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddScoped<ISaleRepository, SaleRepository>();

builder.Services.AddScoped<ISaleDetailRepository, SaleDetailRepository>();

builder.Services.AddMediatR(typeof(CommandCreateSale.Manager).Assembly);

builder.Services.AddHttpClient("Products", config => config.BaseAddress = new Uri(builder.Configuration["Services:Products"]));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
