using Microsoft.AspNetCore.Mvc.Rendering;

namespace Garage2Grupp5.Services
{
    public interface IMemberFullNameService
    {
        Task<IEnumerable<SelectListItem>> GetMemberFullNamesAsync();
    }
}
