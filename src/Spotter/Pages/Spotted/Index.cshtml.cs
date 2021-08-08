using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

        [BindProperty]
        public string SearchText { get; set; }

        public IList<PlaneViewModel> Model { get;set; }

        public async Task OnGetAsync()
        {
            Model = _mapper.Map<List<PlaneViewModel>>(await _queryService.GetAllAsync());
        }

        public async Task OnPostAsync()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                Model = new List<PlaneViewModel>();
                // todo: indicate no records found
            }
            else
            {
                var recordSet = await _queryService.BasicSearchAsync(SearchText);
                if (recordSet.Count > 0)
                {
                    Model = _mapper.Map<List<PlaneViewModel>>(recordSet);
                }
                else
                {
                    Model = new List<PlaneViewModel>();
                    // todo: indicate no records found
                }
            }
        }
    }
}
