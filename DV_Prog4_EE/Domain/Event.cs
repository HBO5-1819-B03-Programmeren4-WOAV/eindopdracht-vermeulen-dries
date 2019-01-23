using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prog5_eindopdracht_DV.Domain
{
    public class Event: EntityBase
    {
        public string Name { get; set; }
        public string Activity { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }
        //public bool IsRecurring { get; set; }

        public Group Owner { get; set; }
        public List<ApplicationUser> Invitees { get; set; }
    }
}
