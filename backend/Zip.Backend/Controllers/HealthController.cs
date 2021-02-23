using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zip.Backend.Data;
using Zip.Backend.Models;

namespace Zip.Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthController : ControllerBase
    {
        private readonly GuestBookContext _db;

        public HealthController(GuestBookContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<GetHealthResponse>> Get()
        {
            var healthy = true;
            try
            {
                await _db.Database.ExecuteSqlRawAsync("SELECT 1");
            }
            catch (Exception)
            {
                healthy = false;
            }
            return StatusCode(healthy ? 200 : 500, new GetHealthResponse()
            {
                Healthy = healthy
            });
        }
    }
}
