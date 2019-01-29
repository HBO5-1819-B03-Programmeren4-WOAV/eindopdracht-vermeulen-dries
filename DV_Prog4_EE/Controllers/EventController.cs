using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DV_Prog4_EE.Domain;
using DV_Prog4_EE.Enums;
using DV_Prog4_EE.Filters;
using DV_Prog4_EE.Models;
using DV_Prog4_EE.Repositories.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Prog5_eindopdracht_DV.Controllers
{
    [Authorize]
    [ServiceFilter(typeof(UserFilter))]
    public class EventController : Controller
    {
        private IUserRepository _userRepository;
        private IEventRepository _eventRepository;
        private IGroupRepository _groupRepository;
        public EventController(IUserRepository userRepository, IEventRepository eventRepository, IGroupRepository groupRepository)
        {
            _userRepository = userRepository;
            _eventRepository = eventRepository;
            _groupRepository = groupRepository;
        }

        public IActionResult Index(AppUser user)
        {
            EventIndexViewModel vm = new EventIndexViewModel();
            vm.Events = _eventRepository.GetAll().ToList();
            foreach(Event e in vm.Events)
            {
                e.Invitees = _userRepository.GetUsersForEvent(e.Id);
            }
            return View(vm);
        }

        public IActionResult Edit(ActionType mode, int id)
        {
            EventViewModel vm = new EventViewModel();
            vm.Type = mode;
            Event e = _eventRepository.GetBy(id);
            if(id != 0)
            {
                vm.Action = e.Activity;
                vm.Description = e.Description;
                vm.From = e.From;
                vm.To = e.To;
                vm.Name = e.Name;
            }
            return View(vm);
        }

        public IActionResult Create(AppUser user,ActionType mode)
        {
            EventViewModel vm = new EventViewModel();
            vm.Type = mode;
            return View(vm);
        }
        [HttpPost]
        public IActionResult Create(AppUser user, EventViewModel vm)
        {
            try
            {
                Event e = new Event();
                e.Name = vm.Name;
                e.Activity = vm.Action;
                e.Description = vm.Description;
                e.From = vm.From;
                e.To = vm.To;
                e.Owner = _groupRepository.GetBy(user.GroupName);
                e.Invitees = new List<AppUser>();
                e.Invitees.Add(user);
                _eventRepository.Add(e);
                _eventRepository.AddLinkToUser(new Event_User(user.Email, e.Id));
                
            }
            catch(Exception e)
            {
                return RedirectToAction(nameof(Create), ActionType.Create);
            }
            return RedirectToAction(nameof(Index),"Group");
        }
    }
}