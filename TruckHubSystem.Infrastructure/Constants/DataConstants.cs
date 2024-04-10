using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckHubSystem.Infrastructure.Constants
{
    public class DataConstants
    {
        public const int TransmissionTypeNameMaxLength = 10;


        public const int LoadCategoryNameMaxLength = 100;


        public const int BookingStatusNameMaxLength = 20;


        public const int TruckManufacturerNameMaxLength = 50;
        public const int TruckModelNameMaxLength = 100;
        public const int TruckLicensePlateMaxLength = 30;
        public const int YearManufacturedMin = 1960;

        public const int LoadNameMaxLength = 200;
        public const int LoadWeigthMinKg = 1;
        public const int LoadWeightMaxKg = 150000;
        public const int CityNameMaxLength = 100;
        public const int MinimumLoadPrice = 1;
        public const int MaximumLoadPrice = 5000000;
        public const int MinDistanceInKm = 1;
        public const int MaxDistanceInKm = 1000;

        public const int DriverNameMaxLength = 100;
        public const int PhoneNumberMaxLength = 15;

        public const int MinYearDrivingLicenceAcquired = 1960;

        public const int FactoryNameMaxLength = 200;
    }
}
