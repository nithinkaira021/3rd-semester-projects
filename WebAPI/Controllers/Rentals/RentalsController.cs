﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc_surfboard.Data;
using mvc_surfboard.Models;

namespace WebAPI.Controllers.Rentals
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class RentalsController : ControllerBase
    {
        private readonly mvc_surfboardContext _context;

        public RentalsController(mvc_surfboardContext context)
        {
            _context = context;
        }

        // GET: api/Rentals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rental>>> GetRental()
        {
            if (_context.Rental == null)
            {
                return NotFound();
            }
            return await _context.Rental.ToListAsync();
        }

        // GET: api/Rentals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rental>> GetRental(int id)
        {
            if (_context.Rental == null)
            {
                return NotFound();
            }
            var rental = await _context.Rental.FindAsync(id);

            if (rental == null)
            {
                return NotFound();
            }

            return rental;
        }

        // PUT: api/Rentals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRental(int id, Rental rental)
        {
            if (id != rental.RentalId)
            {
                return BadRequest();
            }

            _context.Entry(rental).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentalExists(id))
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

        // POST: api/Rentals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Rental>> PostRental(Rental rental)
        {
            if (_context.Rental == null)
            {
                return Problem("Entity set 'mvc_surfboardContext.Rental'  is null.");
            }
            _context.Rental.Add(rental);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRental", new { id = rental.RentalId }, rental);
        }

        // DELETE: api/Rentals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRental(int id)
        {
            if (_context.Rental == null)
            {
                return NotFound();
            }
            var rental = await _context.Rental.FindAsync(id);
            if (rental == null)
            {
                return NotFound();
            }

            _context.Rental.Remove(rental);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RentalExists(int id)
        {
            return (_context.Rental?.Any(e => e.RentalId == id)).GetValueOrDefault();
        }
    }
}
