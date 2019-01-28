using DV_Prog4_EE.Domain;
using DV_Prog4_EE.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DV_Prog4_EE.Models
{
    public class GroupIndexViewModel
    {
        public List<string> MemberNames { get; set; }
        [Required(ErrorMessage="Please fill in a name")]
        public string Name { get; set; }
        public string Interest { get; set; }
        public List<Event> Events { get; set; }
        public string AdminName { get; set; }
        public ViewType mode { get; set; }
        public List<string> MemberEmails { get; set; }
        public List<AppUser> Members { get; set; }
        public string UserName { get; set; }
        public GroupIndexViewModel()
        {
            
        }
    }
}
