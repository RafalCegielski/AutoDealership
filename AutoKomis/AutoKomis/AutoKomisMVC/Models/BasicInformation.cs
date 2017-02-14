using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoKomisMVC.Models
{
    public class BasicInformation
    {
        public int BasicInformationID { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime OpenedFrom { get; set; }
        public DateTime OpenedTo { get; set; }
        public DateTime SaturdayOpenedFrom { get; set; }
        public DateTime SaturdayOpenedTo { get; set; }
    }
}