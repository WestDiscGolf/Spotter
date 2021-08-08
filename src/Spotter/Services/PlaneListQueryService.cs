using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spotter.Abstractions;
using Spotter.Data;
using Spotter.Models;

namespace Spotter.Services
{
    public class PlaneListQueryService : IPlaneListQueryService
    {
        private readonly SpotterContext _context;

        public PlaneListQueryService(SpotterContext context)
        {
            _context = context;
        }

        public async Task<List<Plane>> GetAllAsync() => await _context.Plane.ToListAsync();
    }
}