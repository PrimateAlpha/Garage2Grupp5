using Microsoft.AspNetCore.Mvc.Rendering;

namespace Garage2Grupp5.Services
{
    public interface IVehicleTypeSelectListService
    {
        Task<IEnumerable<SelectListItem>> GetVehicleTypesAsync();
    }
}