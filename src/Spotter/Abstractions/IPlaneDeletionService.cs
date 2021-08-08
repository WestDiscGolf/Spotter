using System.Threading.Tasks;

namespace Spotter.Abstractions
{
    public interface IPlaneDeletionService
    {
        Task DeleteByIdAsync(int id);
    }
}