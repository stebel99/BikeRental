using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BikeRental.API.Models;
using BikeRental.API.Repository;

namespace BikeRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BikeController : ControllerBase
    {
        private readonly IBikeRepository _repository;

        public BikeController(IBikeRepository repository)
        {
            _repository = repository;
        }
        // GET: api/Bike
        [HttpGet]
        public ActionResult<IEnumerable<Bike>> GetBikes()
        {
            return Ok(_repository.GetBikes());
        }

        // GET: api/Bike/5
        [HttpGet("{id}")]
        public ActionResult<Bike> GetBike(Guid id)
        {
            var bike = _repository.GetBikeById(id);

            if (bike == null)
            {
                return NotFound();
            }

            return bike;
        }

        // PUT: api/Bike/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutBike(Guid id, Bike bike)
        {
            if (!_repository.BikeExist(id))
            {
                return NotFound();
            }
            bike.Id = id;
            _repository.UpdateBike(bike);

            try
            {
                _repository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_repository.BikeExist(id))
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

        // POST: api/Bike
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<Bike> PostBike(Bike bike)
        {
            bike.StatusId = 1; // Status available
            _repository.InsertBike(bike);
            _repository.Save();

            return CreatedAtAction("GetBike", new { id = bike.Id }, bike);
        }

        // DELETE: api/Bike/5
        [HttpDelete("{id}")]
        public ActionResult<Bike> DeleteBike(Guid id)
        {
            var bike = _repository.GetBikeById(id);
            if (bike == null)
            {
                return NotFound();
            }

            _repository.DeleteBike(id);
            _repository.Save();

            return bike;
        }
    }
}
