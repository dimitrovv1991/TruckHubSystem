using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckHubSystem.Infrastructure.Data.Models;

namespace TruckHubSystem.Infrastructure.Data.SeedDb
{
    internal class SeedData
    {
        public Driver FirstDriver {  get; set; }
        public Driver SecondDriver {  get; set; }
        public Driver ThirdDriver {  get; set; }
        public Driver FourthDriver {  get; set; }
        public Driver FifthDriver {  get; set; }

        public Truck FirstTruck { get; set; }
        public Truck SecondTruck { get; set; }
        public Truck ThirdTruck { get; set; }
        public Truck FourthTruck { get; set; }
        public Truck FifthTruck { get; set; }
        public IdentityUser FirstGuestUser { get; set; }
        public IdentityUser SecondGuestUser { get; set; }

        public Factory FirstFactory {  get; set; }
        public Factory SecondFactory {  get; set; }
        public Factory ThirdFactory {  get; set; }

        public Load FirstLoad { get; set; }
        public Load SecondLoad { get; set; }
        public Load ThirdLoad { get; set; }
        public Load FourthLoad { get; set; }
        public Load FifthLoad { get; set; }

        public CurrentLoad FirstCurrentLoad { get; set; }
        public CurrentLoad SecondCurrentLoad { get; set; }
        public CurrentLoad ThirdCurrentLoad { get; set; }
        public CurrentLoad FourthCurrentLoad { get; set; }
        public CurrentLoad FifthCurrentLoad { get; set; }
        public SeedData()
        {
            SeedDrivers();
            SeedTrucks();
            SeedUsers();
            SeedFactories();
            SeedLoads();
            SeedCurrentLoads();
        }

        private void SeedCurrentLoads()
        {
            FirstCurrentLoad = new CurrentLoad()
            {
                Id = 1,
                LoadId = 1,
                FactoryId = 1
            };

            SecondCurrentLoad = new CurrentLoad()
            {
                Id = 2,
                LoadId = 2,
                FactoryId = 1
            };

            ThirdCurrentLoad = new CurrentLoad()
            {
                Id = 3,
                LoadId = 3,
                FactoryId = 2
            };

            FourthCurrentLoad = new CurrentLoad()
            {
                Id = 4,
                LoadId = 4,
                FactoryId = 3
            };

            FifthCurrentLoad = new CurrentLoad()
            {
                Id = 5,
                LoadId = 5,
                FactoryId = 3
            };
        }
        private void SeedLoads()
        {
            FirstLoad = new Load()
            {
                Id = 1,
                FactoryId = 1,
                Weigth = 12000,
                IsLoadAvailable = true,
                Name = "Detergents",
                LoadCategoryId = 5
            };

            SecondLoad = new Load()
            {
                Id = 2,
                FactoryId = 1,
                Weigth = 19000,
                IsLoadAvailable = true,
                Name = "Detergents",
                LoadCategoryId = 5
            };

            ThirdLoad = new Load()
            {
                Id = 3,
                FactoryId = 2,
                Weigth = 7000,
                IsLoadAvailable = true,
                Name = "Machines",
                LoadCategoryId = 8
            };

            FourthLoad = new Load()
            {
                Id = 4,
                FactoryId = 3,
                Weigth = 22000,
                IsLoadAvailable = true,
                Name = "Plastics",
                LoadCategoryId = 1
            };

            FifthLoad = new Load()
            {
                Id = 5,
                FactoryId = 3,
                Weigth = 21000,
                IsLoadAvailable = true,
                Name = "Plastics",
                LoadCategoryId = 5
            };
        }
        private void SeedFactories()
        {
            FirstFactory = new Factory()
            {
                Id = 1,
                Name = "Ficosotta",
                Location = "Shumen",
                CreatorId = "kiu12856-c198-6532-jf28-b893d8395280"
            };

            SecondFactory = new Factory()
            {
                Id = 2,
                Name = "Husqvarna",
                Location = "Ruse",
                CreatorId = "kiu12856-c198-6532-jf28-b893d8395280"
            };

            ThirdFactory = new Factory()
            {
                Id = 3,
                Name = "Plastchim",
                Location = "Varna",
                CreatorId = "b893d8395280-jf28-6532-c198-kiu12856"
            };
        }
        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            FirstGuestUser = new IdentityUser()
            {
                Id = "kiu12856-c198-6532-jf28-b893d8395280",
                UserName = "guest@gmail.com",
                NormalizedUserName = "guest@gmail.com",
                Email = "guest@gmail.com",
                NormalizedEmail = "guest@gmail.com"
            };

            FirstGuestUser.PasswordHash =
                hasher.HashPassword(FirstGuestUser, "guest123");

            SecondGuestUser = new IdentityUser()
            {
                Id = "b893d8395280-jf28-6532-c198-kiu12856",
                UserName = "guest2@gmail.com",
                NormalizedUserName = "guest2@gmail.com",
                Email = "guest2@gmail.com",
                NormalizedEmail = "guest2@gmail.com"
            };

            SecondGuestUser.PasswordHash =
                hasher.HashPassword(SecondGuestUser, "guest2123");
        }

        private void SeedDrivers()
        {
            FirstDriver = new Driver()
            {
                Id = 1,
                FirstName = "Georgi",
                FamilyName = "Georgiev",
                IsDriverAvailable = true,
                PhoneNumber = "0883442233",
                YearDrivingLicenseAcquired = 2002
            };

            SecondDriver = new Driver()
            {
                Id = 2,
                FirstName = "Ivan",
                FamilyName = "Ivanov",
                IsDriverAvailable = true,
                PhoneNumber = "0883445566",
                YearDrivingLicenseAcquired = 2005
            };

            ThirdDriver = new Driver()
            {
                Id = 3,
                FirstName = "Petar",
                FamilyName = "Petrov",
                IsDriverAvailable = true,
                PhoneNumber = "0883447788",
                YearDrivingLicenseAcquired = 2010
            };

            FourthDriver = new Driver()
            {
                Id = 4,
                FirstName = "Stefan",
                FamilyName = "Stefanov",
                IsDriverAvailable = true,
                PhoneNumber = "0883449900",
                YearDrivingLicenseAcquired = 2015
            };

            FifthDriver = new Driver()
            {
                Id = 5,
                FirstName = "Vasil",
                FamilyName = "Vasilev",
                IsDriverAvailable = true,
                PhoneNumber = "0883441122",
                YearDrivingLicenseAcquired = 2020
            };
        }

        private void SeedTrucks()
        {
            FirstTruck = new Truck()
            {
                Id = 1,
                Available = true,
                CapacityKg = 14000,
                LicensePlate = "P7777PP",
                Manufacturer = "Man",
                Model = "TGX",
                YearManufactured = 2021,
                ImageUrl = "https://content.presspage.com/uploads/2678/6a533810-4bd3-4c85-b7cc-cefe06c5ef1c/1920_njitransport-5.jpg"
            };


            SecondTruck = new Truck()
            {
                Id = 2,
                Available = true,
                CapacityKg = 15000,
                LicensePlate = "C1234CC",
                Manufacturer = "Mercedes-Benz",
                Model = "Actros",
                YearManufactured = 2022,
                ImageUrl = "https://autobild.bg/wp-content/uploads/2020/09/Actros-Edition-2-3.jpg"
            };

            ThirdTruck = new Truck()
            {
                Id = 3,
                Available = true,
                CapacityKg = 13000,
                LicensePlate = "PB5678BB",
                Manufacturer = "Volvo",
                Model = "FH",
                YearManufactured = 2020,
                ImageUrl = "http://www.autoconsulting.com.ua/pictures/others/2019/Volvo_FH_iSave_01.jpg"
            };

            FourthTruck = new Truck()
            {
                Id = 4,
                Available = true,
                CapacityKg = 12000,
                LicensePlate = "B9999BB",
                Manufacturer = "DAF",
                Model = "XF",
                YearManufactured = 2019,
                ImageUrl = "https://autobild.bg/wp-content/uploads/2021/11/DAF-XF-Hydrogen_Truck-Innovation-Award.jpg"
            };

            FifthTruck = new Truck()
            {
                Id = 5,
                Available = true,
                CapacityKg = 13500,
                LicensePlate = "A1111AA",
                Manufacturer = "Scania",
                Model = "R Series",
                YearManufactured = 2021,
                ImageUrl = "https://img.carswp.com/scania/r-series/scania_r-series_2014_images_1.jpg"
            };
        }
    }
}
