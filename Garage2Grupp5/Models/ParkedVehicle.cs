﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Garage2Grupp5.Models
{
    public class ParkedVehicle
    {
        [Key] public int Id { get; set; }

        [Required]
        [Display(Name = "LicensePlate")]
        [StringLength(20)]
        [Remote("IsLicensePlateExist", "ParkedVehicle", AdditionalFields = "Id",
                ErrorMessage = "LicensePlate already exists")]
        public string LicensePlate { get; set; } = string.Empty;

        public VehicleType Type { get; set; }

        [Display(Name = "Nr of wheels")]
        [Range(0, 20)]
        //public int Type { get; set; }
        public int NrOfWheels { get; set; }

        public string Color { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public DateTime ArrivalTime { get; set; } = DateTime.Parse(DateTime.Now.ToString("g"));

        public DateTime DepartureTime { get; set; } = DateTime.Parse(DateTime.Now.ToString("g"));

        public decimal Price { get; set; }
    }
}
