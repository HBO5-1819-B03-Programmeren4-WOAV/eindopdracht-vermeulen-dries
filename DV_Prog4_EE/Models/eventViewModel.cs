using DV_Prog4_EE.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DV_Prog4_EE.Models
{
    public class EventViewModel
    {
        public string Action { get; set; }
        public string Name { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime From { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime To { get; set; }
        public string Description { get; set; }
        public ActionType Type { get; set; }

        public EventViewModel()
        {
            From = DateTime.Today;
            To = DateTime.Today.AddDays(1);
        }

    }
}
