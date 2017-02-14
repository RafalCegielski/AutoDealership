    using AutoKomisMVC.DAL;
using AutoKomisMVC.Infrastructure;
using AutoKomisMVC.Models;
using AutoKomisMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoKomisMVC.Controllers
{
    public class HomeController : Controller
    {
        private UsedCarDealerContext db = new UsedCarDealerContext();

        // GET: Home
        public ActionResult HomePage()
        {
            ICacheProvider cache = new DefaultCacheProvider();


            List<Advertisment> newAdvertisments;
            if (cache.IsSet(Consts.NewAdvertismentCacheKey))
            {
                newAdvertisments = cache.Get(Consts.NewAdvertismentCacheKey) as List<Advertisment>;
            }
            else
            {
                newAdvertisments = db.Advertisments.OrderByDescending(a => a.AdvertCreateDare).Take(4).ToList();
                cache.Set(Consts.NewAdvertismentCacheKey, newAdvertisments, 2);
            }

           // var add = db.Advertisments.FirstOrDefault().AdvertPhotos.FirstOrDefault().PhotoFileName;
            var basicInformation = db.BasicInformations.FirstOrDefault();

            var vm = new HomeViewModel()
            {
                NewAdvertisments = newAdvertisments,
                OpenedFrom = basicInformation.OpenedFrom.ToString("H:mm"),
                OpenedTo = basicInformation.OpenedTo.ToString("H:mm"),
                SaturdayOpenedFrom = basicInformation.SaturdayOpenedFrom.ToString("H:mm"),
                SaturdayOpenedTo = basicInformation.SaturdayOpenedTo.ToString("H:mm"),
                PhoneNumber = basicInformation.PhoneNumber
            };
            return View(vm);
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Route()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult ContactData()
        {
            //ICacheProvider cache = new DefaultCacheProvider();

            //BasicInformation basicInformation;
            //if (cache.IsSet(Consts.BasicDataCacheKey))
            //{
            //    basicInformation = cache.Get(Consts.BasicDataCacheKey) as BasicInformation;
            //}
            //else
            //{
            //    basicInformation = db.BasicInformations.FirstOrDefault();
            //    cache.Set(Consts.BasicDataCacheKey, basicInformation, 30);
            //}
            var basicInformation = db.BasicInformations.FirstOrDefault();
            var basicInformationDTO = new BasicInformationDTO()
            {
                OpenedFrom = basicInformation.OpenedFrom.ToString("H:mm"),
                OpenedTo = basicInformation.OpenedTo.ToString("H:mm"),
                SaturdayOpenedFrom = basicInformation.SaturdayOpenedFrom.ToString("H:mm"),
                SaturdayOpenedTo = basicInformation.SaturdayOpenedTo.ToString("H:mm"),
                PhoneNumber = basicInformation.PhoneNumber
            };

            return PartialView("_ContactData", basicInformationDTO);
        }
    }
}
