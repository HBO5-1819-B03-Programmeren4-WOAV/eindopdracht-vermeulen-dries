﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prog5_eindopdracht_DV.Enums;
namespace Prog5_eindopdracht_DV.Domain
{
    public class Invitation: EntityBase
    {
        public ApplicationUser Sender { get; set; }
        public ApplicationUser Receiver { get; set; }
        //Depending on wether the following attributes are null it could be a friend invitation, an event invitation or a group invitation
        public Event Event { get; set; }
        public Group Group { get; set; }
        // but we still add a type to be sure
        public InvitationType Type {get;set;}
    }
}
