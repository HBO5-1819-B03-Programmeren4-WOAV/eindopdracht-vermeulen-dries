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
using DV_Prog4_EE.Enums;

namespace Prog5_eindopdracht_DV.Controllers
{
    [Authorize]
    [ServiceFilter(typeof(UserFilter))]
    public class ProfileController : Controller
    {
        private IUserRepository _userRepository;
        private IGroupRepository _groupRepository;
        private IInvitationRepository _invitationRepository;
        public ProfileController(IUserRepository userRepository, IGroupRepository groupRepository, IInvitationRepository invitationRepository)
        {
            _userRepository = userRepository;
            _groupRepository = groupRepository;
            _invitationRepository = invitationRepository;
        }
        public IActionResult Index(AppUser user)
        {
            ProfileViewModel vm = new ProfileViewModel();
            vm.FirstName = user.FirstName;
            vm.LastName = user.LastName;
            vm.Interests = user.Interests;
            vm.mode = ViewType.Owner;
            if(user.GroupName != null)
            {
                vm.HasGroup = true;
            }
            else
            {
                vm.HasGroup = false;
            }
            vm.Invites = _invitationRepository.GetByUserId(user.Email);
            foreach(Invitation i in vm.Invites)
            {
                i.Group = _groupRepository.GetById(i.GroupId);
            }

            return View(vm);
        }

        public IActionResult Edit(AppUser user)
        {
            ProfileViewModel vm = new ProfileViewModel();
            vm.FirstName = user.FirstName;
            vm.LastName = user.LastName;
            vm.Interests = user.Interests;
            vm.mode = ViewType.Owner;
            return View(vm);
        }
        [HttpPost]
        public IActionResult Edit(AppUser user,ProfileViewModel vm)
        {
            if (vm.FirstName != null)
            {
                user.FirstName = vm.FirstName;
            }
            if (vm.LastName != null)
            {
                user.LastName = vm.LastName;
            }
            if (vm.Interests != null)
            {
                user.Interests = vm.Interests;
            }
            _userRepository.Update(user).Wait();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Join(AppUser user, int Id)
        {
            Group g = _groupRepository.GetById(Id);
            user.GroupName = g.Name;
            
           _userRepository.Update(user).Wait();
            g.Members.Add(user);
            _groupRepository.Update(g).Wait();
            return RedirectToAction(nameof(Index),"Group");
        }
    }
}