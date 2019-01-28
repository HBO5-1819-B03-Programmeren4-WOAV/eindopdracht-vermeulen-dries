using DV_Prog4_EE.Domain;
using DV_Prog4_EE.Repositories.Base;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DV_Prog4_EE.Filters
{
    public class UserFilter : ActionFilterAttribute
    {
        
            private readonly IUserRepository _userRepository;
            private AppUser _user;

            public UserFilter(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            public override void OnActionExecuting(ActionExecutingContext context)
            {
            
                context.ActionArguments["user"] = context.HttpContext.User.Identity.IsAuthenticated ? _userRepository.GetBy(context.HttpContext.User.Identity.Name) : null;
                base.OnActionExecuting(context);
            }
            public override void OnActionExecuted(ActionExecutedContext context)
            {
                base.OnActionExecuted(context);
            }
        
    }
}
