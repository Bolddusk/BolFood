using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BolFood.core;
using BolFood.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BolFood
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;
        public Restaurant Restaurant { get; set; }
        public DetailModel(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }
        
        public IActionResult OnGet(int restaurantId)
        {
            //var restaurant = _restaurantData.get
            Restaurant = _restaurantData.GetRestaurantById(restaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}