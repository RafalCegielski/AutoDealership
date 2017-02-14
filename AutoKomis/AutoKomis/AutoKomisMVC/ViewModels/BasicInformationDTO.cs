using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoKomisMVC.ViewModels
{
    public class BasicInformationDTO
    {
        public int BasicInformationID { get; set; }
        public string PhoneNumber { get; set; }
        public string OpenedFrom { get; set; }
        public string OpenedTo { get; set; }
        public string SaturdayOpenedFrom { get; set; }
        public string SaturdayOpenedTo { get; set; }
    }
}