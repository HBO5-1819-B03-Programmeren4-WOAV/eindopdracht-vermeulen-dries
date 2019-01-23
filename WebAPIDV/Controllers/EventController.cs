using Microsoft.AspNetCore.Mvc;
using Prog5_eindopdracht_DV.Domain;
using WebAPIDV.Repositories;

namespace WebAPIDV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : BaseController<Event, EventRepository>
    {
        public EventController(EventRepository eventRepository) : base(eventRepository)
        {

        }
    }
}