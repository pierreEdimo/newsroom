using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsroom.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class DefauiltController : ControllerBase
    {
        [Route("/")]
        [Route("/swagger")]
        public RedirectResult Index()
        {
            return new RedirectResult("~/swagger");
        }
    }  
}
