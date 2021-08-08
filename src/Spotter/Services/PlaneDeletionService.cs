using System.Threading.Tasks;
using Spotter.Abstractions;
using Spotter.Data;

namespace Spotter.Services
{
    public class PlaneDeletionService : IPlaneDeletionService
    {
        private readonly SpotterContext _context;

        public PlaneDeletionService(SpotterContext context)
        {
            _context = context;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var plane = await _context.Plane.FindAsync(id);
            if (plane != null)
            {
                _context.Plane.Remove(plane);
                await _context.SaveChangesAsync();
            }
        }
    }
}