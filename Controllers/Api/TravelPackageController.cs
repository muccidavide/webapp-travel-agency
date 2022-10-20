using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using webapp_travel_agency.Data;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers.Api
{
    [Route("api/travel/")]
    [ApiController]
    public class TravelPackageController : ControllerBase
    {

        TravelContext _ctx;
      

        public TravelPackageController()
        {
            _ctx = new TravelContext();
          

        }
        public IActionResult Get(string? title)
        
        {
            if(title == null)
            {
                List<TravelPackage> travels = _ctx.TravelPackages.ToList();
                return Ok(travels);
            }
            else
            {

                List<TravelPackage> travelsByName = _ctx.TravelPackages.Where(t => t.Name.ToLower().Contains(title)).ToList();
                List<TravelPackage> travelsByDesc = _ctx.TravelPackages.Where(t => t.Description.ToLower().Contains(title)).ToList();
                foreach(TravelPackage t in travelsByName)
                {
                    travelsByDesc.Add(t);
                }
                
                return Ok(travelsByDesc);
            }
            
        }
    }
}
