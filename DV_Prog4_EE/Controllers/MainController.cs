using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DV_Prog4_EE.Filters;
using DV_Prog4_EE.Domain;
using DV_Prog4_EE.Repositories.Base;
using DV_Prog4_EE.Models;

namespace DV_Prog4_EE.Controllers
{
    [Authorize]
    [ServiceFilter(typeof(UserFilter))]
    public class MainController : Controller
    {
        private IUserRepository _userRepository;
        public MainController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index(AppUser user)
        {
            if(user == null)
            {
                _userRepository.Add(new AppUser(HttpContext.User.Identity.Name));
            }
            user = new AppUser(HttpContext.User.Identity.Name);
            return View(new MainViewModel(user));
        }
    }
}