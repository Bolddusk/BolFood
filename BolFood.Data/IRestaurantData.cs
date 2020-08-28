using BolFood.core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BolFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }

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
        public IEnumerable<Restaurant> GetAll() => from r in restaurants
                                                   orderby r.Name
                                                   select r;
    }
}
