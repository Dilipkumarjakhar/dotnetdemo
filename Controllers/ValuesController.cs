using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationwithApiAndAngular.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {

        //[Route("api/test")]
        [HttpGet] public IActionResult Get()
        {

       
            return Content("test api.......");
        }
    }
}
