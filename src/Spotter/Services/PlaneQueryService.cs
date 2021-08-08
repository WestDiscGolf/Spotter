using System.Collections.Generic;
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
    }
}