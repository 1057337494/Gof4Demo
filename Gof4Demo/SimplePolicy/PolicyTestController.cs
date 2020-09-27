using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gof4Demo.SimplePolicy
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PolicyTestController : ControllerBase
    {
        [Authorize(Policy = "policy1")]
        public string Test()
        {
            return "访问成功";
        }

    }
}