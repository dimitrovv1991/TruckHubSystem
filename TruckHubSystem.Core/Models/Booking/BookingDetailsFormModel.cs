namespace TruckHubSystem.Core.Models.Booking
{
    public class BookingDetailsFormModel
    {
        public int Id { get; set; }
        public string LoadName { get; set; }

        public int LoadWeigth { get; set; }
        public string LoadingFactoryName { get; set; }

        public string LoadingCityName { get; set; }

        public string TruckManufacturer {  get; set; }

        public string TruckPlateNumber {  get; set; }

        public string TruckImage { get; set; }

        public string DriverFirstName {  get; set; }

        public string DriverLastName { get; set; }

        public int BookingStatusId { get; set; }

        public string BookingCreatorId {  get; set; }

        public int ReceivingFactoryId { get; set; }

        public string ReceivingFactoryName { get; set; }

        public string ReceivingFactoryCityName { get; set; }
    }
}
