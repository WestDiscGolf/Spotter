using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Spotter.Abstractions;
using Spotter.ViewModels;

namespace Spotter.Pages.Spotted
{
    public class DeleteModel : PageModel
    {
        private readonly IPlaneQueryService _queryService;
        private readonly IPlaneDeletionService _deletionService;
        private readonly IMapper _mapper;

        public DeleteModel(
            IPlaneQueryService queryService, 
            IPlaneDeletionService deletionService, 
            IMapper mapper)
        {
            _queryService = queryService;
            _deletionService = deletionService;
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _deletionService.DeleteByIdAsync(id.Value);
            return RedirectToPage("./Index");
        }
    }
}
