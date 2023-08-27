using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationwithApiAndAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DilipController1 : ControllerBase
    {

        /// <summary>
        /// please provide placeid and placeName
        /// </summary>
        /// <returns></returns>
        [HttpGet]

        public string Get()
        {
            return "dilip";
        }
    }
}
