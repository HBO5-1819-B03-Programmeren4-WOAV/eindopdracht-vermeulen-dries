using DV_Prog4_EE.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DV_Prog4_EE.Models
{
    public class MainViewModel
    {
        public MainViewModel(AppUser user)
        {
            User = user;
        }

        public AppUser User { get; set; }
    }
}
