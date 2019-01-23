using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prog5_eindopdracht_DV.Domain;

namespace Prog5_eindopdracht_DV.Models
{
    public class ProfileViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> Interests { get; set; }
        public List<ApplicationUser> Friends { get; set; }
        
    }
}
