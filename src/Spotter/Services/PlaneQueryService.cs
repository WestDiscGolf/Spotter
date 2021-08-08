using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spotter.Abstractions;
using Spotter.Data;
using Spotter.Models;

namespace Spotter.Services
{
    public class PlaneQueryService : IPlaneQueryService
    {
        private readonly SpotterContext _context;

        public PlaneQueryService(SpotterContext context)
        {
            _context = context;
        }

        public async Task<List<Plane>> GetAllAsync() => await _context.Plane.ToListAsync();
        
        public async Task<Plane> FindByIdAsync(int id) => await _context.Plane.FirstOrDefaultAsync(m => m.Id == id);

        public async Task<List<Plane>> BasicSearchAsync(string searchText)
        {
            var recordSet = await _context.Plane.Where(x =>
                    x.Model.Contains(searchText)
                    || x.Make.Contains(searchText)
                    || x.Registration.Contains(searchText))
                .ToListAsync();

            return recordSet;
        }
    }
}