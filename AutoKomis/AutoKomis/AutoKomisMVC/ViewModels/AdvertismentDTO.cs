using AutoKomisMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AutoKomisMVC.ViewModels
{
    public class AdvertismentDTO
    {

        public int AdvertismentID { get; set; }
        public string Price { get; set; }
        public string BrandOfCar { get; set; }
        public string ModelOfCar { get; set; }
        public int YearOfCreate { get; set; }
        public int EngineCapacity { get; set; }
        public string FluelType { get; set; }
        public string Gearbox { get; set; }
        public string BodyType { get; set; }
        public int EnginePower { get; set; }
        public int Mileage { get; set; }
        public int NumberOfDoor { get; set; }
        public string Equipment { get; set; }
        public string Description { get; set; }
        public DateTime AdvertCreateDare { get; set; }

        public List<AdvertPhotos> AdvertPhotos { get; set; }
    }
}