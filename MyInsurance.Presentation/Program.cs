using Microsoft.EntityFrameworkCore;
using MyInsurance.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using MyInsurance.Application.Interfaces;
using MyInsurance.Application.Services;
using MyInsurance.Domain.Interfaces;
using MyInsurance.Infrastructure.Data.Repositories;
using MyInsurance.Application.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container

builder.Services.AddDbContextFactory<AppDbContext>((service,opt) => { 
    var conf = service.GetRequiredService<IConfiguration>();
    opt.UseSqlServer(conf.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<ICoverageService, CoverageService>();
builder.Services.AddScoped<ICoverageRepository, CoverageRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionHandler>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
