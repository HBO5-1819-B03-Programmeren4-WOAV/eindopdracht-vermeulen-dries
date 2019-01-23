using Microsoft.AspNetCore.Mvc;
using DV_Prog4_EE.Domain;
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