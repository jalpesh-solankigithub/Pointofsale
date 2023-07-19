﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pointofsale_Terminal.Data;
using Pointofsale_Terminal.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Pointofsale_TerminalContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Pointofsale_TerminalContext") ?? throw new InvalidOperationException("Connection string 'Pointofsale_TerminalContext' not found.")));

// Add services to the container.
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
