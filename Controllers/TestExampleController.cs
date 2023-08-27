using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationwithApiAndAngular.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

   
    public class TestExampleController : ControllerBase
    {
        [HttpGet]
        public string Test()
        {
            return "example test....";
        }
    }
}
