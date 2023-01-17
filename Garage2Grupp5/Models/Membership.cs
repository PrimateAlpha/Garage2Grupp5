﻿using ActiveLogin.Identity.Swedish.AspNetCore.Validation;
using System.ComponentModel.DataAnnotations;
#nullable disable
namespace Garage2Grupp5.Models
{
    public class Membership
    {
        [Key] public int Id { get; set; }

        //Navigation properties        
        //public ICollection<ParkedVehicle> ParkedVehicles { get; set; }
        //public ICollection<Enrollment> Enrollments { get; set; }

        //[Required(ErrorMessage = "Social Security Number is Required")]
        //[RegularExpression(@"^\d{9}|\d{3}-\d{2}-\d{4}$", ErrorMessage = "Invalid Social Security Number")]
        //[PersonalIdentityNumber]

        [PersonalIdentityNumber]
        public string SocialSecurityNumber { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => $"{FirstName} {LastName}";


    }
}
