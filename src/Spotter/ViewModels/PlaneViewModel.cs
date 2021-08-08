using System;
using System.ComponentModel.DataAnnotations;

namespace Spotter.ViewModels
{
    public class PlaneViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(128, ErrorMessage = "Make can only be 128 characters long.")]
        public string Make { get; set; }

        [Required]
        [MaxLength(128, ErrorMessage = "Model can only be 128 characters long.")]
        public string Model { get; set; }

        [Required]
        public string Registration { get; set; }

        [Required]
        [MaxLength(255, ErrorMessage = "Location can only be 255 characters long.")]
        public string Location { get; set; }

        [Required]
        [CustomValidation(typeof(PlaneViewModel), nameof(ValidateSeenDateTime))]
        public DateTime SeenDateTime { get; set; }

        public static ValidationResult ValidateSeenDateTime(DateTime seenDateTime, ValidationContext context)
        {
            if (seenDateTime >= DateTime.Now)
            {
                return new ValidationResult("Can't see a plane in the future.");
            }

            return ValidationResult.Success;
        }
    }
}
