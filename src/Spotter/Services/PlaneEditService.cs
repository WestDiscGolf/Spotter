using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spotter.Abstractions;
using Spotter.Data;
using Spotter.Models;
using Spotter.Pages.Spotted;

namespace Spotter.Services
{
    public class PlaneEditService : IPlaneEditService
    {
        private readonly SpotterContext _context;

        public PlaneEditService(SpotterContext context)
        {
            _context = context;
        }

        public async Task<(bool FoundToUpdate, Plane UpdatedEntity)> UpdateAsync(Plane plane)
        {
            _context.Attach(plane).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaneExists(plane.Id))
                {
                    return (false, null);
                }

                throw;
            }

            return (true, plane);
        }

        private bool PlaneExists(int id)
        {
            return _context.Plane.Any(e => e.Id == id);
        }
    }
}