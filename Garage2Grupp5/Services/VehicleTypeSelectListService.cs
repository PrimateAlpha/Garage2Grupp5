using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Garage2Grupp5.Data;

namespace Garage2Grupp5.Services
{
    public class VehicleTypeSelectListService : IGenreSelectListService
    {
        private readonly MovieDemoContext _context;

        public GenreSelectListService(MovieDemoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SelectListItem>> GetGenresAsync()
        {
            return await _context.Movie.Select(m => m.Genre)
                                .Distinct()
                                .Select(g => new SelectListItem
                                {
                                    Text = g.ToString(),
                                    Value = g.ToString()
                                })
                                .ToListAsync();
        }
    }
}
