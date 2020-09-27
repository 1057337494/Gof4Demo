using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gof4Demo.SimplePolicy
{
    public class MinAgePolicy: IAuthorizationRequirement
    {
        public MinAgePolicy(int age)
        {
            Age = age;
        }

        public int Age { get; set; }


    }
}
