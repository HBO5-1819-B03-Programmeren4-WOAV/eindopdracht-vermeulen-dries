using Microsoft.AspNetCore.Mvc;
using Prog5_eindopdracht_DV.Domain;
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
