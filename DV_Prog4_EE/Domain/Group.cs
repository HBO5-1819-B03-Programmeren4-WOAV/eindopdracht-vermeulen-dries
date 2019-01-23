using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prog5_eindopdracht_DV.Domain
{
    public class Group:EntityBase
    {
        public string Name { get; set; }
        public List<ApplicationUser> Members { get; set; }
        public List<string> Interests { get; set; }

        public List<Event> Events { get; set; }

        public List<ApplicationUser> Admins { get; set; }

        public List<string> InternalMessages { get; set; }
        public Group(string name)
        {
            Name = name;
        }
    }
}
