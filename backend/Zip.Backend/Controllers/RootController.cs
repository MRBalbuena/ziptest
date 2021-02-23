using Microsoft.AspNetCore.Mvc;
using Zip.Backend.Models;

namespace Zip.Backend.Controllers
{
    [ApiController]
    [Route("")]
    public class RootController : ControllerBase
    {
        [HttpGet]
        public GetRootResponse Get()
        {
            return new GetRootResponse()
            {
                Application = "Guest Book"
            };
        }
    }
}