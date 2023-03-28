using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Store.Api.Products.Persistence;
using Store.Api.Products.Persistence.Repositories;
using Store.Api.Products.Persistence.Repositories.Base;
using Store.Api.Products.Services.Commands;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(
    cfg => cfg.RegisterValidatorsFromAssemblyContaining<CommandCreateProduct>()
    );

builder.Services.AddDbContext<ContextProduct>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("ConexionDb"));
});

builder.Services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
builder.Services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));

builder.Services.AddScoped<ICommandProductRepository, CommandProductRepository>();
builder.Services.AddScoped<IQueryProductRepository, QueryProductRepository>();


builder.Services.AddMediatR(typeof(CommandCreateProduct.Manager).Assembly);

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
