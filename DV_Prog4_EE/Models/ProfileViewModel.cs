using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DV_Prog4_EE.Domain;

namespace DV_Prog4_EE.Models
{
    public class ProfileViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> Interests { get; set; }
        public List<ApplicationUser> Friends { get; set; }
        
    }
}
