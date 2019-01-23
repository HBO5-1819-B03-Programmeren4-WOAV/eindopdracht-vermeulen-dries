using Microsoft.AspNetCore.Mvc;
using Prog5_eindopdracht_DV.Domain;
using WebAPIDV.Repositories;

namespace WebAPIDV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvitationController : BaseController<Invitation, InvitationRepository>
    {
        public InvitationController(InvitationRepository invitationRepository) : base(invitationRepository)
        {

        }
    }
}