using Microsoft.EntityFrameworkCore;
using projeto1.Data;
using projeto1.Interfaces;
using projeto1.Repositories;

var builder = WebApplication.CreateBuilder(args);

// 1. Serviços (ANTES do Build)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IStockRepository,StockRepository>();


var app = builder.Build();

// 2. Pipeline (DEPOIS do Build)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
