using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DV_Prog4_EE.Domain
{
    public class Group:EntityBase
    {
        public string Name { get; set; }
        public List<AppUser> Members { get; set; }
        public string Interest { get; set; }
        public List<Event> Events { get; set; }
        public AppUser AdminId { get; set; }
        public Group(string name)
        {
            Name = name;
        }
    }
}
