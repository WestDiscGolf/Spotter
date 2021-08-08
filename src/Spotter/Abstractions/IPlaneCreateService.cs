using System.Threading.Tasks;
using Spotter.Models;

namespace Spotter.Abstractions
{
    public interface IPlaneCreateService
    {
        Task SaveAsync(Plane plane);
    }
}