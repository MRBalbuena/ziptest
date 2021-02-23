using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zip.Backend.Data;
using Zip.Backend.Models;

namespace Zip.Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GuestsController : ControllerBase
    {
        private readonly GuestBookContext _db;

        public GuestsController(GuestBookContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IEnumerable<Guest>> Get()
        {
            var guests = await _db.GuestBook.ToListAsync();
            return guests;
        }

        [HttpPost]
        public async Task<Guest> Create(CreateGuestRequest newGuestRequest)
        {
            var guest = new Guest()
            {
                Id = Guid.NewGuid(),
                FirstName = newGuestRequest.FirstName,
                LastName = newGuestRequest.LastName,
                Created = DateTime.Now.ToUniversalTime()
            };

            await _db.GuestBook.AddAsync(guest);
            await _db.SaveChangesAsync();

            return guest;
        }
    }
}
