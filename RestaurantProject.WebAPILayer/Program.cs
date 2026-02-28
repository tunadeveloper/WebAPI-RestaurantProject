using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using RestaurantProject.WebAPILayer.AutoMapper;
using RestaurantProject.WebAPILayer.Context;
using RestaurantProject.WebAPILayer.Repositories;
using RestaurantProject.WebAPILayer.UnitOfWorks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApiContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
        );
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(typeof(GeneralMapping));
builder.Services.AddControllers()
       .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();