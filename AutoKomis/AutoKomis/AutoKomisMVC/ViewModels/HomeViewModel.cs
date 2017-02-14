using AutoKomisMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoKomisMVC.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Advertisment> NewAdvertisments { get; set; }
    
        public string PhoneNumber { get; set; }
        public string OpenedFrom { get; set; }
        public string OpenedTo { get; set; }
        public string SaturdayOpenedFrom { get; set; }
        public string SaturdayOpenedTo { get; set; }
    }
}