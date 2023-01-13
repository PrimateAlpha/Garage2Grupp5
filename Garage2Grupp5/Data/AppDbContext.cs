using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Threading.Tasks;
using Garage2Grupp5.Models;
using Microsoft.EntityFrameworkCore;
using Garage2Grupp5.ViewModels;

namespace Garage2Grupp5.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<ParkedVehicle> ParkedVehicle => Set<ParkedVehicle>();
        public DbSet<VehicleType> VehicleType => Set<VehicleType>();
    }
}