using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Spotter.Abstractions;
using Spotter.Models;
using Spotter.ViewModels;

namespace Spotter.Pages.Spotted
{
    public class CreateModel : PageModel
    {
        private readonly IPlaneCreateService _createService;
        private readonly IRegistrationValidationService _registrationValidationService;
        private readonly IMapper _mapper;

        public CreateModel(IPlaneCreateService createService,
            IRegistrationValidationService registrationValidationService,
            IMapper mapper)
        {
            _createService = createService;
            _mapper = mapper;
            _registrationValidationService = registrationValidationService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PlaneViewModel Model { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            (var registrationValid, var errorMessage) = await _registrationValidationService.ValidateAsync(Model.Registration);

            if (!registrationValid)
            {
                ModelState.AddModelError("Model.Registration", errorMessage);
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var model = _mapper.Map<Plane>(Model);
            await _createService.SaveAsync(model);

            return RedirectToPage("./Index");
        }
    }
}
