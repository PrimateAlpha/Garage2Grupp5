﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Garage2Grupp5.Data;
using System;
using Garage2Grupp5.Models;
//var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<Garage2Grupp5Context>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("Garage2Grupp5Context") ?? throw new InvalidOperationException("Connection string 'Garage2Grupp5Context' not found.")));

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IParkedVehicleRepository, ParkedVehicleRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
