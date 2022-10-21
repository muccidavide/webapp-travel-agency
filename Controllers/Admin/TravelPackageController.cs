using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Cryptography.Xml;
using webapp_travel_agency.Data;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers.Admin
{

    [Authorize]
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

            travelData.TravelPackage.Tags = _ctx.Tags.Where(ingredient => travelData.SelectedTags.Contains(ingredient.Id)).ToList<Tag>();
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            TravelPackage travel = _ctx.TravelPackages.Where(t => t.Id == id).FirstOrDefault();

            if(travel == null)
            {
                return NotFound();
            }

            _ctx.TravelPackages.Remove(travel);
            _ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        
        public IActionResult Update(int id)
        {

            TravelPackage travelToUpdate = _ctx.TravelPackages.Where(t => t.Id == id).Include(t => t.Transport).Include(t => t.Category).Include(t => t.Destination).Include(t => t.Tags).FirstOrDefault();

            if(travelToUpdate == null)
            {
                return NotFound();
            }

            travelSupportModel.TravelPackage = travelToUpdate;
            return View(travelSupportModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, TravelSupportModel travelData)
        {
            TravelPackage travelToUpdate = _ctx.TravelPackages.Where(t => t.Id == id).Include(t => t.Transport).Include(t => t.Category).Include(t => t.Destination).Include(t => t.Tags).FirstOrDefault();

            if (travelToUpdate == null)
            {
                return NotFound();
            }

            travelToUpdate.Name = travelData.TravelPackage.Name;
            travelToUpdate.Description = travelData.TravelPackage.Description;
            travelToUpdate.CoverImage = travelData.TravelPackage.CoverImage;
            travelToUpdate.Description = travelData.TravelPackage.Description;
            travelToUpdate.DepartureDate = travelData.TravelPackage.DepartureDate;
            travelToUpdate.ReturnDate = travelData.TravelPackage.ReturnDate;
            travelToUpdate.Price = travelData.TravelPackage.Price;
            travelToUpdate.CategoryId = travelData.TravelPackage.CategoryId;
            travelToUpdate.TransportId = travelData.TravelPackage.TransportId;
            travelToUpdate.DestinationId = travelData.TravelPackage.DestinationId;
            travelToUpdate.Tags = _ctx.Tags.Where(tag => travelData.SelectedTags.Contains(tag.Id)).ToList<Tag>();

            try
            {
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("StoreDataExcetipn", ex.Message);
               
                return View("Update", travelData);

            }

            return RedirectToAction("Index");


            
        }

    }
}
