using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoKomisMVC.Models
{
    public class Cars
    {
        public int CarsID { get; set; }
        public string BrandOfCar { get; set; }

        public virtual IEnumerable<ModelOfCar> ModelOfCars { get; set; }
    }
}