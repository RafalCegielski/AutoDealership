using AutoKomisMVC.DAL;
using AutoKomisMVC.Models;
using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoKomisMVC.Infrastructure
{
    public class AdvertismentDetailsDynamicNodeProvider : DynamicNodeProviderBase
    {

        private UsedCarDealerContext db = new UsedCarDealerContext();
        
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var returnValue = new List<DynamicNode>();
            foreach(Advertisment a in db.Advertisments)
            {
                DynamicNode dn = new DynamicNode();
                dn.Title = a.BrandOfCar + ' ' + a.ModelOfCar;
                dn.RouteValues.Add("id", a.AdvertismentID);
                dn.RouteValues.Add("BrandOfCar", a.BrandOfCar);
                dn.RouteValues.Add("ModelOfCar", a.ModelOfCar);
                returnValue.Add(dn);
            }
            return returnValue;
        } 


    }
}