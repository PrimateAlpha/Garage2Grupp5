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
        //public DbSet<ParkedVehicleViewModel> ParkedVehicleViewModel => Set<ParkedVehicleViewModel>();
        public DbSet<Membership> Membership => Set<Membership>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VehicleType>().HasData(
                 new VehicleType { Id = 1, Name = "Car"},
                   new VehicleType { Id = 2, Name = "Motorcycle"},
                   new VehicleType { Id = 3, Name = "Bus"},
                   new VehicleType { Id = 4, Name = "Boat"}
                   
                );
        }


        //public DbSet<Garage2Grupp5.ViewModels.ParkedVehicleViewModel> ParkedVehicleViewModel { get; set; }
        //public DbSet<Garage2Grupp5.Models.Membership> Membership { get; set; }
    }
}