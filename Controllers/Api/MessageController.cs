using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapp_travel_agency.Data;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        TravelContext _ctx;
        public MessageController()
        {
            _ctx = new TravelContext();
        }

        [HttpPost]
        public IActionResult Send([FromBody] Message messageData)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Contact", "Home", messageData);
            }
            Message newMessage = new Message();
            newMessage = messageData;
            _ctx.Messages.Add(newMessage);
            _ctx.SaveChanges();


            return Ok();

        }

        [Authorize]
        public IActionResult Get(string? title)
        {
            if (title == null)
            {
                List<Message> messages = _ctx.Messages.ToList();
                return Ok(messages);
            }
            else
            {
                List<Message> messages = _ctx.Messages.Where(p => p.Title.ToLower().Contains(title)).ToList();
                return Ok(messages);
            }
        }
    }
}
