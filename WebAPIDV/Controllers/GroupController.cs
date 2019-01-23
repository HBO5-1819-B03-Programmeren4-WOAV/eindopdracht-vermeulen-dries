using Microsoft.AspNetCore.Mvc;
using DV_Prog4_EE.Domain;
using WebAPIDV.Repositories;

namespace WebAPIDV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController: BaseController<Group, GroupRepository>
    {
        public GroupController(GroupRepository groupRepository): base(groupRepository)
        {

        }
    }
}
