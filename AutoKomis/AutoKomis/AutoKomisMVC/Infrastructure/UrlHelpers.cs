using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoKomisMVC.Infrastructure
{
    public static class UrlHelpers
    {
        public static string CarPhotoPath(this UrlHelper helper,string carPhotoFileName)
        {
            var carPhotoFolder = AppConfig.CarPhotosFolderRelative;
            var path = Path.Combine(carPhotoFolder, carPhotoFileName);
            var apsolutePath = helper.Content(path);
            return apsolutePath;
        }
    }
}