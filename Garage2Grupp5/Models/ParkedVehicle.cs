using System.ComponentModel.DataAnnotations;

namespace Garage2Grupp5.Models
{
    public class ParkedVehicle
    {
        [Key] public int Id { get; set; }

        [Required]
        [Display(Name = "LicensePlate")]
        [StringLength(20)]
        /*[Key] */public string LicensePlate { get; set; }

        public string Type { get; set; }
        [Display(Name = "Type")]
        [Range(5, 100)]
        //public int Type { get; set; }
        public string Department { get; set; }
    }
}
