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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Prog5_eindopdracht_DV.Controllers
{
    [Authorize]
    [ServiceFilter(typeof(UserFilter))]
    public class SearchController : Controller
    {
        private IUserRepository _userRepository;
        private IGroupRepository _groupRepository;
        private IEventRepository _eventRepository;
        private IInvitationRepository _invitationRepository;

        public SearchController(IUserRepository userRepository,IEventRepository eventRepository,IGroupRepository groupRepository, IInvitationRepository invitationRepository)
        {
            _userRepository = userRepository;
            _groupRepository = groupRepository;
            _eventRepository = eventRepository;
            _invitationRepository = invitationRepository;
        }
        public IActionResult Index(AppUser user)
        {
            SearchViewModel vm = new SearchViewModel();
            SelectList s = new SelectList(new List<string>() { "People", "Events", "Groups" });
            ViewBag.Values = s;
            vm.Users = _userRepository.GetAll().ToList();
            vm.Filter = "People";
            vm.User = user;
            return View(vm);
        }

        [HttpPost]
        public IActionResult Index(AppUser user, string Id)
        {
            SearchViewModel vm = new SearchViewModel();
            SelectList s = new SelectList(new List<string>() { "People", "Events", "Groups" });
            ViewBag.Values = s;
            switch (Id)
            {
                case "People":
                    vm.Users = _userRepository.GetAll().ToList();
                    vm.Filter = "People";
                    break;
                case "Events":
                    vm.Events = _eventRepository.GetAll().ToList();
                    vm.Filter = "Events";
                    break;
                case "Groups":
                    vm.Groups = _groupRepository.GetAll().ToList();
                    vm.Filter = "Groups";
                    break;
            }
            vm.User = user;
            return View(vm);
        }
        [HttpPost]
        public IActionResult Invite(AppUser user, string email)
        {
            try
            {
                Invitation i = new Invitation();
                i.Group = _groupRepository.GetBy(user.GroupName);
                i.ReceiverEmail = email;
                i.SenderName = user.Email;
                _invitationRepository.Add(i);
            }
            catch (Exception e)
            {
                TempData["message"] = "Something went wrong while trying to invite " + email;
                return RedirectToAction(nameof(Index));
            }
            TempData["message"] = "Invited user " + email ;
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Subscribe(AppUser user, int id)
        {
            try
            {
                Event_User ev = new Event_User(user.Email, id);
                _eventRepository.AddLinkToUser(ev).Wait();
            }
            catch(Exception e)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), "Event");
        }
    }
}