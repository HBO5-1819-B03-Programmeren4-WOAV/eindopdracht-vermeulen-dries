using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DV_Prog4_EE.Domain;
using DV_Prog4_EE.Enums;

namespace DV_Prog4_EE.Models
{
    public class ProfileViewModel
    {
        [Required(ErrorMessage = "Please fill in your first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please fill in your last name")]
        public string LastName { get; set; }
        
        public string Interests { get; set; }
        public ViewType mode { get; set; }
        public List<Invitation> Invites { get; set; }
        public bool HasGroup { get; set; }
    }
}
