using BolFood.core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BolFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly BolFoodDbContext db;

        public SqlRestaurantData(BolFoodDbContext db)
        {
            this.db = db;
        }
        public Restaurant Add(Restaurant restaurant)
        {
            db.Restaurants.Add(restaurant);
            return restaurant;    
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetRestaurantById(id);
            if(restaurant != null)
            {
                db.Restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public int GetCountOfRestaurants() 
            => db.Restaurants.Count();

        public Restaurant GetRestaurantById(int id) => 
            db.Restaurants.Find(id);

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            return db.Restaurants.Where(r => r.Name.StartsWith(name) || string.IsNullOrEmpty(name) ).ToList();

            var query = from r in db.Restaurants
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;

            return query;
        }
        public Restaurant Update(Restaurant restaurant)
        {
            var entity = db.Restaurants.Attach(restaurant);
            entity.State = EntityState.Modified;
            return restaurant;
        }
    }
}
