using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Garage2Grupp5.Data;

namespace Garage2Grupp5.Services
{
    public class VehicleTypeSelectListService : IVehicleTypeSelectListService
    {
        private readonly AppDbContext _context;

        public VehicleTypeSelectListService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SelectListItem>> GetVehicleTypesAsync()
        {
            return await _context.VehicleType
                                .Select(g => new SelectListItem
                                {
                                    Text = g.Name.ToString(),
                                    Value = g.Name.ToString()
                                })
                                .ToListAsync();
        }
    }
}
