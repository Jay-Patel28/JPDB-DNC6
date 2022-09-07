﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JPDB.Data;
using JPDB.Model;

namespace JPDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarOwners1Controller : ControllerBase
    {
        private readonly JPDBContext _context;

        public CarOwners1Controller(JPDBContext context)
        {
            _context = context;
        }

        // GET: api/CarOwners1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarOwner>>> GetCarOwners()
        {
          if (_context.CarOwners == null)
          {
              return NotFound();
          }
            return await _context.CarOwners.ToListAsync();
        }

        // GET: api/CarOwners1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarOwner>> GetCarOwner(int id)
        {
          if (_context.CarOwners == null)
          {
              return NotFound();
          }
            var carOwner = await _context.CarOwners.FindAsync(id);

            if (carOwner == null)
            {
                return NotFound();
            }

            return carOwner;
        }

        // PUT: api/CarOwners1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarOwner(int id, CarOwner carOwner)
        {
            if (id != carOwner.CarId)
            {
                return BadRequest();
            }

            _context.Entry(carOwner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarOwnerExists(id))
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

        // POST: api/CarOwners1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarOwner>> PostCarOwner(CarOwner carOwner)
        {
          if (_context.CarOwners == null)
          {
              return Problem("Entity set 'JPDBContext.CarOwners'  is null.");
          }
            _context.CarOwners.Add(carOwner);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CarOwnerExists(carOwner.CarId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCarOwner", new { id = carOwner.CarId }, carOwner);
        }

        // DELETE: api/CarOwners1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarOwner(int id)
        {
            if (_context.CarOwners == null)
            {
                return NotFound();
            }
            var carOwner = await _context.CarOwners.FindAsync(id);
            if (carOwner == null)
            {
                return NotFound();
            }

            _context.CarOwners.Remove(carOwner);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarOwnerExists(int id)
        {
            return (_context.CarOwners?.Any(e => e.CarId == id)).GetValueOrDefault();
        }
    }
}
