using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoKomisMVC.Models
{
    public class ModelOfCar
    {
        public int ModelOfCarID { get; set; }
        public string Model { get; set; }
        
        public virtual Cars Car { get; set; }
    }
}