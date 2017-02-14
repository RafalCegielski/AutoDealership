using AutoKomisMVC.Migrations;
using AutoKomisMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace AutoKomisMVC.DAL
{
    public class UsedCarDealerInitializer : MigrateDatabaseToLatestVersion<UsedCarDealerContext, Configuration>
    {
        //protected override void Seed(UsedCarDealerContext context)
        //{
        //    SeedUsedCarDealerData(context);

        //   // base.Seed(context);
        //}

        public static void SeedUsedCarDealerData(UsedCarDealerContext context)
        {
            var Advertisments = new List<Advertisment>
            {
                //new Advertisment() { AdvertCreateDare= DateTime.Now, BodyType="Sedan", BrandOfCar="Audi", YearOfCreate=2002,Description="brak",
                //EngineCapacity=1200,EnginePower=120,Equipment="brak, brak", FluelType="LPG", Gearbox="manual", Mileage=112000,ModelOfCar="A3", NumberOfDoor=5, Price=14000, },

                //new Advertisment() {AdvertismentID=2, AdvertCreateDare=DateTime.Now, BodyType="Sedan", BrandOfCar="Skoda", YearOfCreate=1999,Description="brak",
                //EngineCapacity=1200,EnginePower=120,Equipment="brak, brak", FluelType="LPG", Gearbox="manual", Mileage=123000,ModelOfCar="Fabia", NumberOfDoor=3, Price=11000},

                //new Advertisment() {AdvertismentID=3, AdvertCreateDare=DateTime.Now, BodyType="Sedan", BrandOfCar="Reno", YearOfCreate=2012,Description="brak",
                //EngineCapacity=1200,EnginePower=120,Equipment="brak, brak", FluelType="Diesel", Gearbox="manual", Mileage=320000,ModelOfCar="Megan", NumberOfDoor=5, Price=53000},

                //new Advertisment() {AdvertismentID=4, AdvertCreateDare=DateTime.Now, BodyType="Sedan", BrandOfCar="Peugeot", YearOfCreate=2002,Description="brak",
                //EngineCapacity=1200,EnginePower=120,Equipment="brak, brak", FluelType="Diesel", Gearbox="manual", Mileage=220000,ModelOfCar="307", NumberOfDoor=5, Price=21000}
            };

            Advertisments.ForEach(g => context.Advertisments.AddOrUpdate(g));
            context.SaveChanges();

            var BasicInformation = new BasicInformation();

            BasicInformation.BasicInformationID = 1;
            BasicInformation.OpenedFrom = DateTime.Now;
            BasicInformation.OpenedTo = DateTime.Now;
            BasicInformation.PhoneNumber = "111-111-111";
            BasicInformation.SaturdayOpenedFrom = DateTime.Now;
            BasicInformation.SaturdayOpenedTo = DateTime.Now;

            context.BasicInformations.AddOrUpdate(BasicInformation);
            context.SaveChanges();

        }
    }
}