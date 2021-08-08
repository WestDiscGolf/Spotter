using System.Threading.Tasks;
using Spotter.Abstractions;
using Spotter.Data;
using Spotter.Models;

namespace Spotter.Services
{
    public class PlaneCreateService : IPlaneCreateService
    {
        private readonly SpotterContext _context;

        public PlaneCreateService(SpotterContext context)
        {
            _context = context;
        }

        public async Task SaveAsync(Plane plane)
        {
            _context.Plane.Add(plane);
            await _context.SaveChangesAsync();
        }
    }
}