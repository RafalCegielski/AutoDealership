using AutoKomisMVC.DAL;
using AutoKomisMVC.Infrastructure;
using AutoKomisMVC.Models;
using AutoKomisMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoKomisMVC.Controllers
{
    public class AdminController : Controller
    {
        private UsedCarDealerContext db = new UsedCarDealerContext();
        // GET: Admin
        public ActionResult BasicInformation()
        {
            var basicInformation = db.BasicInformations.FirstOrDefault();

            BasicInformationViewModel basicInformationVM = new BasicInformationViewModel
            {
                Email = basicInformation.Email,
                PhoneNumber = basicInformation.PhoneNumber,
                OpenedFrom = basicInformation.OpenedFrom,
                OpenedTo = basicInformation.OpenedTo,
                SaturdayOpenedTo = basicInformation.SaturdayOpenedTo,
                SaturdayOpenedFrom = basicInformation.SaturdayOpenedFrom
            };

            return View(basicInformationVM);
        }
        [HttpPost]
        public ActionResult BasicInformation(BasicInformationViewModel VM)
        {

            return View();
        }
        public ActionResult AdvertismentsList(string searchQuery = null)
        {
            var advertList = db.Advertisments.Where(a => (searchQuery == null) ||
                                                        a.BrandOfCar.ToLower().Contains(searchQuery.ToLower()) ||
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
                return PartialView("_AdminCarList", advertComplete);
            }

            return View(advertComplete);
        }
        public ActionResult AddAdvertisment()
        {

            var test = new EditCarViewModel();

            test.car = db.Cars;
            test.model = db.ModelOfCars;

            ViewBag.EditFlag = false;
            ViewBag.CarsList = new SelectList(db.Cars, "BrandOfCar", "BrandOfCar");
            ViewBag.ModelList = new SelectList(db.ModelOfCars, "Model", "Model");

            return View(test);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddAdvertisment(EditCarViewModel model, IEnumerable<HttpPostedFileBase> file)
        {
            if (ModelState.IsValid)
            {

                ViewBag.EditFlag = false;
                var f = Request.Form;
                var lastID = db.Advertisments.OrderByDescending(a => a.AdvertismentID).Select(x => x.AdvertismentID).FirstOrDefault();
                model.advert.AdvertCreateDare = DateTime.Now;
                int currentID = lastID + 1;
                model.advert.AdvertismentID = currentID;
                List<AdvertPhotos> imagesList = new List<AdvertPhotos>();
                //  db.Advert.Add(model.advert);

                foreach (var image in file)
                {

                    var fileExt = Path.GetExtension(image.FileName);
                    string filename = Guid.NewGuid() + fileExt;

                    var path = Path.Combine(Server.MapPath(AppConfig.CarPhotosFolderRelative), filename);
                    image.SaveAs(path);



                    imagesList.Add(new AdvertPhotos
                    {
                        PhotoFileName = filename,
                        //Advertisment = model.advert
                    });

                }
                model.advert.AdvertPhotos = imagesList;

                db.Advertisments.Add(model.advert);
                db.SaveChanges();

                return RedirectToAction("AdvertismentsList");
            }

            var test = new EditCarViewModel();
            test.advert = model.advert;
            test.car = db.Cars;
            test.model = db.ModelOfCars;

            ViewBag.CarsList = new SelectList(db.Cars, "BrandOfCar", "BrandOfCar");
            ViewBag.ModelList = new SelectList(db.ModelOfCars, "Model", "Model");
            return View(test);
        }


        public ActionResult ModifyAdvertisment(int id)
        {
            ViewBag.EditFlag = true;
            ViewBag.CarsList = new SelectList(db.Cars, "BrandOfCar", "BrandOfCar");
            ViewBag.ModelList = new SelectList(db.ModelOfCars, "Model", "Model");
            var advert = db.Advertisments.Find(id);

            EditCarViewModel vm = new EditCarViewModel();

            vm.advert = advert;

            TempData["id"] = id;

            return View("AddAdvertisment", vm);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ModifyAdvertisment(EditCarViewModel vm)
        {
            ViewBag.EditFlag = true;
            ViewBag.CarsList = new SelectList(db.Cars, "BrandOfCar", "BrandOfCar");
            ViewBag.ModelList = new SelectList(db.ModelOfCars, "Model", "Model");

            if (ModelState.IsValid)
            {
                var id = TempData["id"];
                Advertisment advert = new Advertisment();
                advert = db.Advertisments.Find(id);


                advert.BodyType = vm.advert.BodyType;
                advert.BrandOfCar = vm.advert.BrandOfCar;
                advert.Color = vm.advert.Color;
                advert.Description = vm.advert.Description;
                advert.EngineCapacity = vm.advert.EngineCapacity;
                advert.EnginePower = vm.advert.EnginePower;
                advert.Equipment = vm.advert.Equipment;
                advert.FluelType = vm.advert.FluelType;
                advert.Gearbox = vm.advert.Gearbox;
                advert.Mileage = vm.advert.Mileage;
                advert.ModelOfCar = vm.advert.ModelOfCar;
                advert.NumberOfDoor = vm.advert.NumberOfDoor;
                advert.Price = vm.advert.Price;
                advert.YearOfCreate = vm.advert.YearOfCreate;

                

                db.Entry(advert).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("AdvertismentsList");
            }
            
            return View("AddAdvertisment", vm);

        }


        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public JsonResult GetCascadeModels(string brand)
        {
            var models = new List<ModelOfCar>();

            if (brand != null)
            {
                models = db.ModelOfCars.Where(m => m.Car.BrandOfCar == brand).ToList();

            }
            return Json(models, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RemoveAdvertisment(int id)
        {
            var advertToRemove = db.Advertisments.Find(id);
            var imgToRemove = db.AdvertPhotos.Where(a => a.Advertisment.AdvertismentID == id).ToList();


            foreach (var img in imgToRemove)
            {
                var path = Path.Combine(Server.MapPath(AppConfig.CarPhotosFolderRelative), img.PhotoFileName);

                System.IO.File.Delete(path);
            }

            db.Advertisments.Remove(advertToRemove);
            db.AdvertPhotos.RemoveRange(imgToRemove);
            db.SaveChanges();

            return RedirectToAction("AdvertismentsList");
        }





    }
}