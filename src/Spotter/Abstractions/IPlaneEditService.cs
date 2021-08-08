using System.Threading.Tasks;
using Spotter.Models;

namespace Spotter.Abstractions
{
    public interface IPlaneEditService
    {
        Task<(bool FoundToUpdate, Plane UpdatedEntity)> UpdateAsync(Plane plane);
    }
}