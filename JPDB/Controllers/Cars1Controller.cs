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
    public class Cars1Controller : ControllerBase
    {
        private readonly JPDBContext _context;

        public Cars1Controller(JPDBContext context)
        {
            _context = context;
        }

        // GET: api/Cars1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCar()
        {
          if (_context.Car == null)
          {
              return NotFound();
          }
            return await _context.Car.ToListAsync();
        }

        // GET: api/Cars1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {
          if (_context.Car == null)
          {
              return NotFound();
          }
            var car = await _context.Car.FindAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            return car;
        }

        // PUT: api/Cars1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(int id, Car car)
        {
            if (id != car.Id)
            {
                return BadRequest();
            }

            _context.Entry(car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(id))
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

        // POST: api/Cars1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Car>> PostCar(CarInputModel carInput)
        {
          if (_context.CarInputModel == null)
          {
              return Problem("Entity set 'JPDBContext.Car'  is null.");
          }
            Car car = new Car();

            car.CarName = carInput.CarName;

            car.CarOwners = null;

            _context.Car.Add(car);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCar", new { id = car.Id }, car);
        }

        // DELETE: api/Cars1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            if (_context.Car == null)
            {
                return NotFound();
            }
            var car = await _context.Car.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            _context.Car.Remove(car);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarExists(int id)
        {
            return (_context.Car?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
