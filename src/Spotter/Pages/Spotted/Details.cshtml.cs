using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Spotter.Abstractions;
using Spotter.ViewModels;

namespace Spotter.Pages.Spotted
{
    public class DetailsModel : PageModel
    {
        private readonly IPlaneQueryService _queryService;
        private readonly IMapper _mapper;

        public DetailsModel(
            IPlaneQueryService queryService, 
            IMapper mapper)
        {
            _queryService = queryService;
            _mapper = mapper;
        }

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
    }
}
