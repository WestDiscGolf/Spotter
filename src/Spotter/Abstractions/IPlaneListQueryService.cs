using System.Collections.Generic;
using System.Threading.Tasks;
using Spotter.Models;

namespace Spotter.Abstractions
{
    public interface IPlaneListQueryService
    {
        Task<List<Plane>> GetAllAsync();
    }
}