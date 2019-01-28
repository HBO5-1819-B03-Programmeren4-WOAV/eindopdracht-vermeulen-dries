using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DV_Prog4_EE.Domain;

namespace DV_Prog4_EE.Models
{
    public class EventIndexViewModel
    {
        public List<Event> Events { get; set; }
        public int UserId { get; set; }
    }
}
