using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DV_Prog4_EE.Models
{
    public class GroupIndexViewModel
    {
        List<string> Names { get; set; }

        public GroupIndexViewModel(List<string> names)
        {
            Names = names;
        }
    }
}
