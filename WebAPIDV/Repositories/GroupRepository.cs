﻿using Prog5_eindopdracht_DV.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDV.Base;
using WebAPIDV.Models;

namespace WebAPIDV.Repositories
{
    public class GroupRepository: Repository<Group>
    {
        public GroupRepository(ApplicationDbContext context): base(context)
        {

        }
    }
}
