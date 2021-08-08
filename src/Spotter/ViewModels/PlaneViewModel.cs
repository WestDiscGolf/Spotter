using System;

namespace Spotter.ViewModels
{
    public class PlaneViewModel
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string Registration { get; set; }

        public string Location { get; set; }

        public DateTime SeenDateTime { get; set; }
    }
}
