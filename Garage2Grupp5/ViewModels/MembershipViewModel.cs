using System.Data.SqlTypes;
#nullable disable
namespace Garage2Grupp5.ViewModels
{
    public class MembershipViewModel
    {
        public string SocialSecurityNumber { get; set; } = string.Empty;
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
    }
}
