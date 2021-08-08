using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Spotter.Abstractions;
using Spotter.Models;
using Spotter.ViewModels;

namespace Spotter.Pages.Spotted
{
    public class EditModel : PageModel
    {
        private readonly IPlaneQueryService _queryService;
        private readonly IPlaneEditService _editService;
        private readonly IMapper _mapper;

        public EditModel(
            IPlaneQueryService queryService, 
            IPlaneEditService editService, 
            IMapper mapper)
        {
            _queryService = queryService;
            _editService = editService;
            _mapper = mapper;
        }

        [BindProperty]
        public PlaneViewModel Model { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plane = await _queryService.FindByIdAsync(id.Value);
            if (plane == null)
            {
                return NotFound();
            }

            Model = _mapper.Map<PlaneViewModel>(plane);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var model = _mapper.Map<Plane>(Model);
            (var found, var updatedModel) = await _editService.UpdateAsync(model);

            if (!found)
            {
                return NotFound();
            }

            // optional: use the updated model to return back to the edit screen and repopulate the VM to continue editing.
            // optional: potential temp message could be added to the model to be found to the view to say it was successful.

            return RedirectToPage("./Index");
        }
    }
}
