using Garage2Grupp5.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Garage2Grupp5.ViewModels
{
    public class EditViewModel
    {
        //public ParkedVehicleViewModel() { }
        //[Key] public int Id { get; set; }
        //[NotMapped]

        public IEnumerable<SelectListItem> VehicleTypes { get; set; } = new List<SelectListItem>();
        public IEnumerable<ParkedVehicle> ParkedVehicles { get; set; } = new List<ParkedVehicle>();


        public int MemberId { get; set; } /*= string.Empty;*/

        [Required]
        [Display(Name = "LicensePlate")]
        [StringLength(20)]
        //Try disable javascript in microsoft edge while debugging this Remote:
        //like this in microsoft edge:
        //Settings -> Preferences ->
        //[Remote("IsLicensePlateExist", "ParkedVehicle", AdditionalFields = "Id",
        //        ErrorMessage = "LicensePlate already exists")]
        public string LicensePlate { get; set; } = string.Empty;

        //public VehicleType Type { get; set; }/* = VehicleType.;*/
        public string VehicleType { get; set; } = string.Empty;
        public int VehicleTypeId { get; set; }

        public int MemberFullName { get; set; }




        [Display(Name = "Nr of wheels")]
        [Range(0, 20)]
        //public int Type { get; set; }
        public int NrOfWheels { get; set; }

        public string Color { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;

        //No ArrivalTime - vehicle is just registered, not yet parked
        //public DateTime ArrivalTime { get; set; } = DateTime.Parse(DateTime.Now.ToString("g"));

        //public DateTime DepartureTime { get; set; } = DateTime.Parse(DateTime.Now.ToString("g"));

        public decimal Price { get; set; }
    }
}
