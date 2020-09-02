using BolFood.core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BolFood.Data
{
    public class InMemoryRestauranData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;
        public InMemoryRestauranData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{Id = 1, Name="Scot's Pizza" , Location = "Maryland" ,Cuisine = CuisineType.Italian},
                new Restaurant{Id = 2, Name="Cukoos" , Location = "Bhara Kahu" ,Cuisine = CuisineType.Pakistani},
                new Restaurant{Id = 3, Name="Cinnamon Club" , Location = "London" ,Cuisine = CuisineType.Mexican},
                new Restaurant{Id = 4, Name="La Coasta" , Location = "California" ,Cuisine = CuisineType.Italian},
            };


        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null) => 
            from r in restaurants
            where String.IsNullOrEmpty(name) || r.Name.StartsWith(name)
            orderby r.Name
            select r;
        public Restaurant GetRestaurantById(int id) =>
            restaurants.SingleOrDefault(r => r.Id == id);

        public Restaurant Update(Restaurant restaurant)
        {
            var DbRestaurant = restaurants.SingleOrDefault(r => r.Id == restaurant.Id);
            if(DbRestaurant != null)
            {
                DbRestaurant.Name = restaurant.Name;
                DbRestaurant.Location = restaurant.Location;
                DbRestaurant.Cuisine = restaurant.Cuisine;
            }
            return DbRestaurant;
        }
        public Restaurant Add(Restaurant restaurant)
        {
            restaurant.Id = restaurants.Max(r => r.Id) + 1;
            restaurants.Add(restaurant);
            return restaurant;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant != null)
                restaurants.Remove(restaurant);
            return restaurant;
        }
        public int Commit()
        {
            return 0;
        }
    }
}
