using DV_Prog4_EE.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DV_Prog4_EE.Models
{
    public class SearchViewModel
    {
        public List<AppUser> Users { get; set; }
        public string Filter { get; set; }
        public List<Event> Events { get; set; }
        public List<Group> Groups { get; set; }
    }
}
