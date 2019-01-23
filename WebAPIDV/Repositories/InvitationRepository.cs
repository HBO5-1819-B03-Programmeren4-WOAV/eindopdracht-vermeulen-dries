﻿using DV_Prog4_EE.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDV.Base;
using WebAPIDV.Models;

namespace WebAPIDV.Repositories
{
    public class InvitationRepository : Repository<Invitation>
    {
        public InvitationRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}