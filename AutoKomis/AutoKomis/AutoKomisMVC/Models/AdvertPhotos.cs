using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoKomisMVC.Models
{
    public class AdvertPhotos
    {
        public int AdvertPhotosID { get; set; }
        public string PhotoFileName { get; set; }

        public virtual Advertisment Advertisment { get; set; }
    }
}