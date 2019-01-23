using DV_Prog4_EE.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDV.Base;
using WebAPIDV.Models;

namespace WebAPIDV.Repositories
{
    public class ApplicationUserRepository : Repository<AppUser>
    {
        public ApplicationUserRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<AppUser> GetBy(string id)
        {
            return GetAll().SingleOrDefault(a => a.Email.Equals(id));
        }
    }
}
