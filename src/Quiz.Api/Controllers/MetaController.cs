using Microsoft.AspNetCore.Mvc;

namespace Quiz.Api.Controllers
{
    public class MetaController : Controller
    {
        [Route("/liveness"), HttpGet]
        public IActionResult Liveness()
        {
            return Ok("It is alive");
        }

        [Route("/readiness"), HttpGet]
        public IActionResult Readiness()
        {
            return Ok("I am ready!");
        }
    }
}
