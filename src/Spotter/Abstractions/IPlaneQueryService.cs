using System.Collections.Generic;
using System.Threading.Tasks;
using Spotter.Models;

namespace Spotter.Abstractions
{
    public interface IPlaneQueryService
    {
        Task<List<Plane>> GetAllAsync();

        Task<Plane> FindByIdAsync(int id);

        Task<List<Plane>> BasicSearchAsync(string searchText);
    }
}