using System;
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
    public class Owners1Controller : ControllerBase
    {
        private readonly JPDBContext _context;

        public Owners1Controller(JPDBContext context)
        {
            _context = context;
        }

        // GET: api/Owners1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Owner>>> GetOwner()
        {
          if (_context.Owner == null)
          {
              return NotFound();
          }
            return await _context.Owner.ToListAsync();
        }

        // GET: api/Owners1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Owner>> GetOwner(int id)
        {
          if (_context.Owner == null)
          {
              return NotFound();
          }
            var owner = await _context.Owner.FindAsync(id);

            if (owner == null)
            {
                return NotFound();
            }

            return owner;
        }

        // PUT: api/Owners1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOwner(int id, Owner owner)
        {
            if (id != owner.Id)
            {
                return BadRequest();
            }

            _context.Entry(owner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OwnerExists(id))
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

        // POST: api/Owners1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Owner>> PostOwner(Owner owner)
        //{
        //  if (_context.Owner == null)
        //  {
        //      return Problem("Entity set 'JPDBContext.Owner'  is null.");
        //  }
        //    _context.Owner.Add(owner);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetOwner", new { id = owner.Id }, owner);
        //}

        //[HttpPost]
        //public async Task<ActionResult<Owner>> PostOwnerWithoutCar(OwnerInputModel ownerInput)
        //{
        //    if (_context.OwnerInputModel == null)
        //    {
        //        return Problem("Entity set 'JPDBContext.Car'  is null.");
        //    }

        //    Owner owner = new Owner();

        //    owner.OwnerName = ownerInput.OwnerName;
        //    owner.CarOwners[0].CarId = ownerInput.CarId;
        //    _context.Owner.Add(owner);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetOwner", new { id = owner.Id }, owner);
        //}

        [HttpPost]
        public async Task<ActionResult<Owner>> PostOwnerWithCar(OwnerInputWithNewCarModel ownerWithCar)
        {
            if (_context.OwnerInputWithNewCarModel == null)
            {
                return Problem("Entity set 'JPDBContext.Car'  is null.");
            }
            Car car = new Car();
            Owner owner = new Owner();


            car.CarName = ownerWithCar.CarName;
            owner.OwnerName = ownerWithCar.OwnerName;

            var carsPresent = _context.Car.Where(c => c.CarName == ownerWithCar.CarName).Select(i => i.Id).ToList();
            var ownerPresent = _context.Owner.Where(c => c.OwnerName == ownerWithCar.OwnerName).Select(i => i.Id).ToList();
            
            bool isCarThere = carsPresent.Count >=1;
            bool isOwnerThere = ownerPresent.Count >= 1;

            var newCardId = 0;
            var newOwnerId = 0;
            car.CarOwners = null;
            owner.CarOwners = null;

            if (!isCarThere)
            {
                _context.Car.Add(car);
            }
            else
            {
                newCardId = carsPresent[0];
            }

            if (!isOwnerThere)
            {
                _context.Owner.Add(owner);
            }
            else
            {
                newOwnerId = ownerPresent[0];
            }


            await _context.SaveChangesAsync();

            if (!isCarThere)
            {
                newCardId = car.Id;
            }
            if (!isOwnerThere)
            {
                newOwnerId = owner.Id;
            }


            CarOwner carOwner = new CarOwner();
            carOwner.CarId = newCardId;
            carOwner.OwnerId = newOwnerId;

            _context.CarOwners.Add(carOwner);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarOwner", new { id = carOwner.CarId }, carOwner);
        }


        // DELETE: api/Owners1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwner(int id)
        {
            if (_context.Owner == null)
            {
                return NotFound();
            }
            var owner = await _context.Owner.FindAsync(id);
            if (owner == null)
            {
                return NotFound();
            }

            _context.Owner.Remove(owner);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OwnerExists(int id)
        {
            return (_context.Owner?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
