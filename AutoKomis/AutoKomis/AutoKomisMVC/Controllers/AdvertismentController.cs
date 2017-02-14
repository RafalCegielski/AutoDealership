using AutoKomisMVC.DAL;
using AutoKomisMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoKomisMVC.Controllers
{
    public class AdvertismentController : Controller
    {
        UsedCarDealerContext db = new UsedCarDealerContext();
        // GET: Advertisment
        public ActionResult AdvertismentList(string searchQuery = null)
        {
            var advertList = db.Advertisments.Where(a => (searchQuery == null)||
                                                        a.BrandOfCar.ToLower().Contains(searchQuery.ToLower())||
                                                        a.ModelOfCar.ToLower().Contains(searchQuery.ToLower())).ToList();


            var f = new NumberFormatInfo { NumberGroupSeparator = " " };
            var advertComplete = new List<AdvertismentDTO>();
            foreach (var advert in advertList)
            {
                var AdvertDTO = new AdvertismentDTO()
                {
                    AdvertCreateDare = advert.AdvertCreateDare,
                    BodyType = advert.BodyType,
                    AdvertPhotos = advert.AdvertPhotos,
                    BrandOfCar = advert.BrandOfCar,
                    Description = advert.Description,
                    EngineCapacity = advert.EngineCapacity,
                    EnginePower = advert.EnginePower,
                    Equipment = advert.Equipment,
                    FluelType = advert.FluelType,
                    AdvertismentID = advert.AdvertismentID,
                    Gearbox = advert.Gearbox,
                    Mileage = advert.Mileage,
                    ModelOfCar = advert.ModelOfCar,
                    NumberOfDoor = advert.NumberOfDoor,
                    YearOfCreate = advert.YearOfCreate,
                    Price = advert.Price.ToString("# ### ### ### ### zł")
                };
                
                advertComplete.Add(AdvertDTO);
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView("_CarList", advertComplete);
            }

            return View(advertComplete);
        }
        public ActionResult AdvertismentDetails(int id)
        {
            var advert = db.Advertisments.Find(id);
            var f = new NumberFormatInfo { NumberGroupSeparator = " " };
            var AdvertDTO = new AdvertismentDTO()
            {
                AdvertCreateDare = advert.AdvertCreateDare,
                BodyType = advert.BodyType,
                AdvertPhotos = advert.AdvertPhotos,
                BrandOfCar = advert.BrandOfCar,
                Description = advert.Description,
                EngineCapacity = advert.EngineCapacity,
                EnginePower = advert.EnginePower,
                Equipment = advert.Equipment,
                FluelType = advert.FluelType,
                AdvertismentID = advert.AdvertismentID,
                Gearbox = advert.Gearbox,
                Mileage = advert.Mileage,
                ModelOfCar = advert.ModelOfCar,
                NumberOfDoor = advert.NumberOfDoor,
                YearOfCreate = advert.YearOfCreate,
                //Price = advert.Price.ToString("# ### ### ### ###")
                Price = advert.Price.ToString("n", f)
            };

            return View(AdvertDTO);
        }
        public ActionResult CarsSugestions(string term)
        {

            var carsBrand = this.db.Advertisments.Where(c => c.BrandOfCar.ToLower().Contains(term.ToLower())).ToList()
                .Take(4).Select(c => new { label = c.BrandOfCar});

            //var carsModel = this.db.Advertisments.Where(c =>  c.ModelOfCar.ToLower().Contains(term.ToLower())).ToList()
            //    .Take(4).Select(c => new { label = c.ModelOfCar });

            //var cars = carsBrand;
           // cars.
           //TODO
            return Json(carsBrand, JsonRequestBehavior.AllowGet);
            
        }

        
    }
}