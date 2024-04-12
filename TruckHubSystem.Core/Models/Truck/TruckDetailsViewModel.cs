namespace TruckHubSystem.Core.Models.Truck
{
    public class TruckDetailsViewModel
    {
        public int Id { get; set; }

        public string Manufacturer { get; set; } = null!;

        public string Model { get; set; } = null!;

        public string LicensePlate { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public int CapacityKg { get; set; }

        public bool Available { get; set; }
    }
}
