using Garage2Grupp5.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Garage2Grupp5.ViewModels
{
    public class UnparkedVehicleViewModel
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public TimeSpan parkingTime { get; set; }
        public double parkingPrice { get; set; }

        [Required]
        [Display(Name = "LicensePlate")]
        [StringLength(20)]
        //Try disable javascript in microsoft edge while debugging this Remote:
        //like this in microsoft edge:
        //Settings -> Preferences ->
        //[Remote("IsLicensePlateExist", "ParkedVehicle", AdditionalFields = "Id",
        //        ErrorMessage = "LicensePlate already exists")]
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
