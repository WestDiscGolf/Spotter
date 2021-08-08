using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Spotter.Data;
using Spotter.Models;

namespace Spotter.Pages.Spotted
{
    public class IndexModel : PageModel
    {
        private readonly SpotterContext _context;

        public IndexModel(SpotterContext context)
        {
            _context = context;
        }

        public IList<Plane> Plane { get;set; }

        public async Task OnGetAsync()
        {
            Plane = await _context.Plane.ToListAsync();
        }
    }
}
