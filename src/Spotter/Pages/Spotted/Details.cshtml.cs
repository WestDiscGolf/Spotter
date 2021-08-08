using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Spotter.Data;
using Spotter.Models;

namespace Spotter.Pages.Spotted
{
    public class DetailsModel : PageModel
    {
        private readonly Spotter.Data.SpotterContext _context;

        public DetailsModel(Spotter.Data.SpotterContext context)
        {
            _context = context;
        }

        public Plane Plane { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Plane = await _context.Plane.FirstOrDefaultAsync(m => m.Id == id);

            if (Plane == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
