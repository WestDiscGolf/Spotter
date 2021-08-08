using System.Threading.Tasks;
using Spotter.Abstractions;

namespace Spotter.Services
{
    public class RegistrationValidationService : IRegistrationValidationService
    {
        public async Task<(bool IsValid, string ErrorMessage)> ValidateAsync(string registrationCode)
        {
            if (string.IsNullOrWhiteSpace(registrationCode))
            {
                return (false, "Registration code can not be empty.");
            }

            var hyphenIndex = registrationCode.IndexOf('-');
            if (hyphenIndex < 0)
            {
                return (false, "Registration code has to contain a hyphen.");
            }

            var lfh = registrationCode.Substring(0, hyphenIndex);
            if (lfh.Length > 2)
            {
                return (false, "Registration code has to start with 1 or 2 characters.");
            }

            var rhd = registrationCode.Substring(hyphenIndex + 1);
            if (rhd.Length > 5)
            {
                return (false, "Registration code has to end with 1, 2, 3, 4 or 5 characters.");
            }

            return (true, null);
        }
    }
}