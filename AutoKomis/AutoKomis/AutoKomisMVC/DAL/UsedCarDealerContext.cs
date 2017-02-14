using AutoKomisMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AutoKomisMVC.DAL
{
    public class UsedCarDealerContext :DbContext
    {
        public UsedCarDealerContext() : base("UsedCarDealerContext")
        {

        }
        static UsedCarDealerContext()
        {
            //Database.SetInitializer<UsedCarDealerContext>(new UsedCarDealerInitializer());
        }

        public DbSet<Advertisment> Advertisments { get; set; }
        public DbSet<BasicInformation> BasicInformations { get; set; }
        public DbSet<Cars> Cars { get; set; }
        public DbSet<ModelOfCar> ModelOfCars { get; set; }
        public DbSet<AdvertPhotos> AdvertPhotos { get; set; }
    }
}