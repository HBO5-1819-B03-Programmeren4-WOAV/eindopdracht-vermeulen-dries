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

        public ProfileController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IActionResult Index(AppUser user)
        {
            ProfileViewModel vm = new ProfileViewModel();
            vm.FirstName = user.FirstName;
            vm.LastName = user.LastName;
            vm.Interests = user.Interests;
            vm.mode = ViewType.Owner;
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
            _userRepository.Update(user);
            return RedirectToAction(nameof(Index));
        }
    }
}