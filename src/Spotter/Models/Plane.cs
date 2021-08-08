using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spotter.Models
{
    public class Plane
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //[MaxLength(128, ErrorMessage = "Make can only be 128 characters long.")]
        public string Make { get; set; }

        //[MaxLength(128, ErrorMessage = "Model can only be 128 characters long.")]
        public string Model { get; set; }

        //[RegularExpression("[A-Z]{0,2}(-)?[A-Z]{1,5}")]
        public string Registration { get; set; }

        public string Location { get; set; }

        public DateTime SeenDateTime { get; set; }
    }
}
