using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Garage2Grupp5.Data;
using System;
using Garage2Grupp5.Services;
using System.Web.Http.Cors;
using System.Web.Http;
//var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<Garage2Grupp5Context>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("Garage2Grupp5Context") ?? throw new InvalidOperationException("Connection string 'Garage2Grupp5Context' not found.")));

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("AppDbContext")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IMemberFullNameService, MemberFullNameService>();

builder.Services.AddScoped<IVehicleTypeSelectListService, VehicleTypeSelectListService>();


//builder.Services.AddScoped<IParkedVehicleRepository, ParkedVehicleRepository>();


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

// Web API configuration and services
//var cors = new EnableCorsAttribute("*", "*", "*");
//HttpConfiguration config = new HttpConfiguration();
//config.EnableCors(cors);

//// Web API routes
//config.MapHttpAttributeRoutes();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ParkedVehicles}/{action=Index}/{id?}");

app.Run();
