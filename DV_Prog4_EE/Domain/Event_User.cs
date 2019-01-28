using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DV_Prog4_EE.Domain
{
    public class Event_User:EntityBase
    {
        public string Email { get; set; }
        public int EventKey { get; set; }
        public Event_User()
        {

        }
        public Event_User(string email, int eventKey)
        {
            Email = email;
            EventKey = eventKey;
        }
    }
}
