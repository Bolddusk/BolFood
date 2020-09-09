using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BolFood.core;
using BolFood.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BolFood.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly BolFoodDbContext _DbContext;

        public RestaurantsController(BolFoodDbContext bolFoodDbContext)
        {
            _DbContext = bolFoodDbContext;
        }

        // GET: api/Restaurants
        [HttpGet]
        public IEnumerable<Restaurant> GetRestaurants()
            => _DbContext.Restaurants;

        // GET: api/restaurants/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestaurant([FromRoute]int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var restaurant = await _DbContext.Restaurants.FindAsync(id);
            if (restaurant == null)
                return NotFound();

            return Ok(restaurant);

        }

        // PUT: api/restaurants/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestaurant(int id,Restaurant restaurant)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != restaurant.Id)
                return BadRequest();

            _DbContext.Entry(restaurant).State = EntityState.Modified;

            try
            {
                await _DbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantExists(id))
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

        // POST: api/restaurants
        [HttpPost]
        public async Task<IActionResult> PostRestaurant([FromBody]Restaurant restaurant)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _DbContext.Restaurants.Add(restaurant);
            await _DbContext.SaveChangesAsync();
            return CreatedAtAction("GetRestaurant", new { id = restaurant.Id });
        }

        // DELETE: api/restaurants/{id}
        [HttpDelete]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var restaurant = await _DbContext.Restaurants.FindAsync(id);
            if (restaurant == null)
                return NotFound();
            _DbContext.Restaurants.Remove(restaurant);
            await _DbContext.SaveChangesAsync();
            return Ok();
        }

        private bool RestaurantExists(int id)
        {
            return (_DbContext.Restaurants.Find(id) == null ? false :true);
        }


    }
}