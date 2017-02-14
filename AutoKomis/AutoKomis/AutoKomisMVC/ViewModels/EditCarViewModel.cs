using AutoKomisMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoKomisMVC.ViewModels
{
    public class EditCarViewModel
    {
        public Advertisment advert { get; set; }
        public IEnumerable<Cars> car { get; set; }
        public IEnumerable<ModelOfCar> model { get; set; }
        public Fluel fluel { get; set; }
        public BodyType bodyType { get; set; }

    }
    public enum Fluel
    {
        Bensyna = 1,
        Diesel = 2,
        LPG = 3
    }
    public enum BodyType
    {
        Sedan = 1,
        Hatchback = 2,
        Kombi = 3,
    }
    public enum Gearbox
    {
        Manualna = 1,
        Automatyczna = 2,
        Półautomatyczna = 3,
    }

}