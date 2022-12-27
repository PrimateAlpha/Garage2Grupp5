using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Garage2Grupp5.Models;

namespace Garage2Grupp5.Data
{
    public class Garage2Grupp5Context : DbContext
    {
        public Garage2Grupp5Context (DbContextOptions<Garage2Grupp5Context> options)
            : base(options)
        {
        }

        public DbSet<Garage2Grupp5.Models.ParkedVehicle> ParkedVehicle { get; set; } = default!;
    }
}
