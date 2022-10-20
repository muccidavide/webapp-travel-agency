using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using webapp_travel_agency.Data;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers.Admin
{
   
    public class TravelPackageController : Controller
    {
        TravelContext _ctx;

        public TravelPackageController(TravelContext ctx)
        {
            _ctx = new TravelContext();
        }

        public IActionResult Index()
        {
            List<TravelPackage> travels = _ctx.TravelPackages.ToList();

            return View(travels);
        }

        //public IActionResult Create(TravelContext travelData)
        //{
        //    return;
        //}

    }
}
