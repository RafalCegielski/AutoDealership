using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoKomisMVC.ViewModels
{
    public class BasicInformationViewModel
    {

       
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime OpenedFrom { get; set; }
        public DateTime OpenedTo { get; set; }
        public DateTime SaturdayOpenedFrom { get; set; }
        public DateTime SaturdayOpenedTo { get; set; }
    }
}