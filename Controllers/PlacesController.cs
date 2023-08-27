using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationwithApiAndAngular.DatabaseContext;
using WebApplicationwithApiAndAngular.Models;

namespace WebApplicationwithApiAndAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PlacesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Places
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Place>>> GetPlaces()
        {
          if (_context.Places == null)
          {
              return NotFound();
          }
            return await _context.Places.ToListAsync();
        }

        // GET: api/Places/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Place>> GetPlace(Guid id)
        {
          if (_context.Places == null)
          {
              return NotFound();
          }
            var place = await _context.Places.FindAsync(id);
            //var x=await  _context.Places.FirstOrDefaultAsync()

            if (place == null)
            {
                return NotFound();
            }

            return place;
        }

        // PUT: api/Places/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlace(Guid id, Place place)
        {
            if (ModelState.IsValid == false)
            {
                return ValidationProblem(ModelState);
            }
            if (id != place.PlaceId)
            {
                //return Problem("please enter valid values");
                return BadRequest();
            }

            _context.Entry(place).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) // concurrency updating data at a time....
            {
                if (!PlaceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Places
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Place>> PostPlace(Place place)
        {
          if (_context.Places == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Places'  is null.");
          }
            _context.Places.Add(place);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlace", new { id = place.PlaceId }, place);
        }

        // DELETE: api/Places/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlace(Guid id)
        {
            if (_context.Places == null)
            {
                return NotFound();
            }
            var place = await _context.Places.FindAsync(id);
            if (place == null)
            {
                return NotFound();
            }

            _context.Places.Remove(place);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlaceExists(Guid id)
        {
            return (_context.Places?.Any(e => e.PlaceId == id)).GetValueOrDefault();
        }
    }
}
