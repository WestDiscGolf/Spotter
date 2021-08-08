using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Spotter.Abstractions;
using Spotter.ViewModels;

namespace Spotter.Pages.Spotted
{
    public class IndexModel : PageModel
    {
        private readonly IPlaneQueryService _queryService;
        private readonly IMapper _mapper;

        public IndexModel(
            IPlaneQueryService queryService, 
            IMapper mapper)
        {
            _queryService = queryService;
            _mapper = mapper;
        }

        public IList<PlaneViewModel> Plane { get;set; }

        public async Task OnGetAsync()
        {
            Plane = _mapper.Map<List<PlaneViewModel>>(await _queryService.GetAllAsync());
        }
    }
}
