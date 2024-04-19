namespace TruckHubSystem.Core.Models.Booking
{
    public class BookingFormModel
    {
        public string LoadName { get; set; }

        public int LoadWeigth { get; set; }
        public string LoadingFactoryName { get; set; }

        public string TruckManufacturer { get; set; }

        public string TruckPlateNumber { get; set; }

        public string TruckImage { get; set; }

        public string DriverFirstName { get; set; }

        public string DriverLastName { get; set; }

        public string FactoryName { get; set; }
        public string FactoryLocation { get; set; }
        public int SelectedLoadId { get; set; }
        public int SelectedTruckId { get; set; }
        public int SelectedDriverId { get; set; }

        public int SelectedFactoryId { get; set; }
    }
}
