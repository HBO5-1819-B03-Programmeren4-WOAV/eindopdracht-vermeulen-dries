using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DV_Prog4_EE.Domain;
using DV_Prog4_EE.Filters;
using DV_Prog4_EE.Models;
using DV_Prog4_EE.Repositories.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Prog5_eindopdracht_DV.Controllers
{
    [Authorize]
    [ServiceFilter(typeof(UserFilter))]
    public class GroupController : Controller
    {
        private IUserRepository _userRepository;
        private IGroupRepository _groupRepository;
        private IEventRepository _eventRepository;
        private IInvitationRepository _invitationRepository;
        public GroupController(IUserRepository userRepository, IGroupRepository groupRepository, IEventRepository eventRepository, IInvitationRepository invitationRepository)
        {
            _userRepository = userRepository;
            _groupRepository = groupRepository;
            _eventRepository = eventRepository;
            _invitationRepository = invitationRepository;
        }
        public IActionResult Index(AppUser user)
        {
            GroupIndexViewModel vm = new GroupIndexViewModel();
            if(user.GroupName != null)
            {
                Group group = _groupRepository.GetBy(user.GroupName);
                group.Events = _eventRepository.GetByGroupId(group.Id);
                if (group.Events != null)
                {
                    vm.Events = new List<Event>();
                    foreach (Event e in group.Events)
                    {
                        vm.Events.Add(e);
                    }
                }
                if (group.Members != null)
                {
                    vm.Members = new List<AppUser>();
                    foreach (AppUser a in group.Members)
                    {
                        vm.Members.Add(a);
                    }
                }
                vm.Name = user.GroupName;
                vm.Interest = group.Interest;
                vm.UserName = user.FirstName + " " + user.LastName;
            }
            
            return View(vm);
        }

        

        public IActionResult Create()
        {
            return View(new GroupIndexViewModel());
        }

        [HttpPost]
        public IActionResult Create(AppUser user, GroupIndexViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Group group = new Group(vm.Name);
                    group.Interest = vm.Interest;
                    group.Members = new List<AppUser>();
                    group.Members.Add(user);
                    _groupRepository.Add(group).Wait();
                    user.GroupName = vm.Name;
                    _userRepository.Update(user).Wait();
                }
            }
            catch(Exception e)
            {
                return View(nameof(Create), vm);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit()
        {
            return View(nameof(Create));
        }
    }
}