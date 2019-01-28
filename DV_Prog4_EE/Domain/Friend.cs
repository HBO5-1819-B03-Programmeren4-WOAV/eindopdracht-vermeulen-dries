using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DV_Prog4_EE.Domain
{
    public class Friend: EntityBase
    {
        public AppUser User1 { get; set; }
        public AppUser User2 { get; set; }
    }
}
