using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gof4Demo.SimplePolicy
{
    public class MinAgePolicyHandler : AuthorizationHandler<MinAgePolicy>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinAgePolicy requirement)
        {
            if (!context.User.HasClaim(s => s.Type == "age"))
            {
                context.Fail();
            }

            var age = Convert.ToDecimal(context.User.FindFirst("age"));
            if (age < requirement.Age)
            {
                context.Fail();
            }

            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
