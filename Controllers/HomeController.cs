using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetWiki.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : Controller
    {
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult("you have reached the home api! To view this app, go to http://localhost:4200");
        }
    }
}
