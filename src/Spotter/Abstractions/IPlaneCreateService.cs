using System.Threading.Tasks;
using Spotter.Models;

namespace Spotter.Pages.Spotted
{
    public interface IPlaneCreateService
    {
        Task SaveAsync(Plane plane);
    }
}