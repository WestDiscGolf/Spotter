using System.Threading.Tasks;

namespace Spotter.Abstractions
{
    public interface IRegistrationValidationService
    {
        Task<(bool IsValid, string ErrorMessage)> ValidateAsync(string registrationCode);
    }
}