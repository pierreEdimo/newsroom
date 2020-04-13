using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace findaDoctor.Controllers
{
    [ApiController]
    [Route("/")]
    public class RootController : ControllerBase
    {

        public IActionResult GetRoot()
        {
            var response = new
            {
                href = Url.Link(nameof(GetRoot), null)

            };

            return Ok(response);
        }
    }
}