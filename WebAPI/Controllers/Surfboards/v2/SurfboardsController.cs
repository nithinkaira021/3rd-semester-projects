using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc_surfboard.Data;
using mvc_surfboard.Models;

namespace WebAPI.Controllers.Surfboards.v2
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class SurfboardsController : ControllerBase
    {
        private readonly mvc_surfboardContext _context;

        public SurfboardsController(mvc_surfboardContext context)
        {
            _context = context;
        }

        // GET: api/Surfboards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Surfboard>>> GetSurfboard()
        {
            if (_context.Surfboard == null)
            {
                return NotFound();
            }

            return await _context.Surfboard.ToListAsync();
        }

        // GET: api/Surfboards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Surfboard>> GetSurfboard(int id)
        {
          if (_context.Surfboard == null)
          {
              return NotFound();
          }
            var surfboard = await _context.Surfboard.FindAsync(id);

            if (surfboard == null)
            {
                return NotFound();
            }

            return surfboard;
        }

        // PUT: api/Surfboards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSurfboard(int id, Surfboard surfboard)
        {
            if (id != surfboard.Id)
            {
                return BadRequest();
            }

            _context.Entry(surfboard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SurfboardExists(id))
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

        // POST: api/Surfboards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Surfboard>> PostSurfboard(Surfboard surfboard)
        {
          if (_context.Surfboard == null)
          {
              return Problem("Entity set 'mvc_surfboardContext.Surfboard'  is null.");
          }
            _context.Surfboard.Add(surfboard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSurfboard", new { id = surfboard.Id }, surfboard);
        }

        // DELETE: api/Surfboards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSurfboard(int id)
        {
            if (_context.Surfboard == null)
            {
                return NotFound();
            }
            var surfboard = await _context.Surfboard.FindAsync(id);
            if (surfboard == null)
            {
                return NotFound();
            }

            _context.Surfboard.Remove(surfboard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SurfboardExists(int id)
        {
            return (_context.Surfboard?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
