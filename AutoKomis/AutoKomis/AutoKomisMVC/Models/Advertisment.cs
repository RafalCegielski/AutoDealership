using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoKomisMVC.Models
{
    public class Advertisment
    {
        public int AdvertismentID { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string BrandOfCar { get; set; }
        [Required]
        public string ModelOfCar { get; set; }
        [Required]
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
        public string Color { get; set; }

        
        public virtual List<AdvertPhotos> AdvertPhotos { get; set; }
    }
}