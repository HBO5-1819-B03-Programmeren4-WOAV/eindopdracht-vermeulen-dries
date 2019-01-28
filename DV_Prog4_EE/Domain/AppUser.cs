using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DV_Prog4_EE.Domain
{
    public class AppUser: EntityBase
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Interests { get; set; }
        public string GroupName { get; set; }
        public List<Invitation> PendingInvites { get; set; }
        
        public AppUser(string email)
        {
            Email = email;
        }
        public AppUser()
        {

        }
    }
}
