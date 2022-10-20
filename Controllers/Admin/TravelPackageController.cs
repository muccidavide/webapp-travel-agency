using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Security.Cryptography.Xml;
using webapp_travel_agency.Data;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers.Admin
{
   
    public class TravelPackageController : Controller
    {
        TravelContext _ctx;
        List<Category> _categories;
        List<Destination> _destination;
        List<Transport> _transport;
        List<Tag> _tags;
        TravelSupportModel travelSupportModel;

        public TravelPackageController()
        {
            _ctx = new TravelContext();
            _categories = _ctx.Categories.ToList();
            _destination = _ctx.Destinations.ToList();
            _transport = _ctx.Transports.ToList();
            _tags = _ctx.Tags.ToList();
            travelSupportModel = new TravelSupportModel();
            travelSupportModel.Tags = _tags;
            travelSupportModel.Destinations = _destination;
            travelSupportModel.Transports = _transport;
            travelSupportModel.Categories = _categories;

        }

        
        

        public IActionResult Index()
        {
            List<TravelPackage> travels = _ctx.TravelPackages.ToList();

            return View(travels);
        }

        public IActionResult Details(int id)
        {
            TravelPackage travel = _ctx.TravelPackages.Where(t=> t.Id == id).FirstOrDefault();
            
            return View(travel);
        }

        public IActionResult Create()
        {
            travelSupportModel.Categories = _categories;
            return View("Create", travelSupportModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TravelSupportModel travelData)
        {
            if (!ModelState.IsValid)
            {
                return View(travelData);
            }
            try
            {
                _ctx.TravelPackages.Add(travelData.TravelPackage);
                _ctx.SaveChanges();
            }
            catch (SqlException ex)
            {
                ModelState.AddModelError("StoreDataExcetipn", ex.Message);
                return View("Create", travelData);
            }
            return RedirectToAction("Index");
        }

    }
}
