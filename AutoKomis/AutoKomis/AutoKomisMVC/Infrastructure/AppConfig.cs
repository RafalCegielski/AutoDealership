using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace AutoKomisMVC.Infrastructure
{
    public class AppConfig
    {
        private static string _CarPhotosFolderRelative = ConfigurationManager.AppSettings["CarPhotosFolder"];

        public static string CarPhotosFolderRelative
        {
            get
            {
                return _CarPhotosFolderRelative;
            }
        }
    }
}