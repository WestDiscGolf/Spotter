using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Spotter.Data;
using Spotter.Models;

namespace Spotter.Pages.Spotted
{
    public class CreateModel : PageModel
    {
        private readonly Spotter.Data.SpotterContext _context;

        public CreateModel(Spotter.Data.SpotterContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Plane Plane { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Plane.Add(Plane);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
