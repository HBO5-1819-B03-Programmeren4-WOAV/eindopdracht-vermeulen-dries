using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prog5_eindopdracht_DV.Domain
{
    public class AppUser:EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<string> Interests { get; set; }
        public List<ApplicationUser> Friends { get; set; }
        public Group Group { get; set; }
        public List<string> PendingInvites { get; set; }
    }
}
