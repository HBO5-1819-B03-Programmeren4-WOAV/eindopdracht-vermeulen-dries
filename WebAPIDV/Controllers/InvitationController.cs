using Microsoft.AspNetCore.Mvc;
using DV_Prog4_EE.Domain;
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