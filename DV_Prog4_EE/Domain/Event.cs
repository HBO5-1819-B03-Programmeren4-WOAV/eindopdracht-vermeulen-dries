using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DV_Prog4_EE.Domain
{
    public class Event : EntityBase
    {
        public string Name { get; set; }
        public string Activity { get; set; }
        public string Description { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public Group Owner { get; set; }
        public List<AppUser> Invitees { get; set; }
    }
}
