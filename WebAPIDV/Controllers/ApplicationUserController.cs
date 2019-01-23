﻿using Microsoft.AspNetCore.Mvc;
using Prog5_eindopdracht_DV.Domain;
using System.Threading.Tasks;
using WebAPIDV.Repositories;

namespace WebAPIDV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : BaseController<AppUser, ApplicationUserRepository>
    {
        public ApplicationUserController(ApplicationUserRepository appuserRepository) : base(appuserRepository)
        {

        }

        [HttpGet]
        [Route("GetLogin/{Email}")]
        public async Task<IActionResult> GetByEmail(string Email)
        {
            return Ok(await repository.GetBy(Email));
        }
    }
}