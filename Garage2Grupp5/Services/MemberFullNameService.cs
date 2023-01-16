using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Garage2Grupp5.Data;

namespace Garage2Grupp5.Services
{
    public class MemberFullNameService : IMemberFullNameService
    {
        private readonly AppDbContext _context;

        public MemberFullNameService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SelectListItem>> GetMemberFullNamesAsync()
        {
            return await _context.Membership
                                .Select(g => new SelectListItem
                                {
                                    Text = g.FullName.ToString(),
                                    Value = g.FullName.ToString()
                                })
                                .ToListAsync();
        }
    }
}
