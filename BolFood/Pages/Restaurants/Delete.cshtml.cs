﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BolFood.core;
using BolFood.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BolFood
{
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        public Restaurant Restaurant{ get; set; }

        public DeleteModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }


        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = restaurantData.GetRestaurantById(restaurantId);
            if (Restaurant == null)
                return RedirectToPage("./NotFound");

            return Page();
        }

        public IActionResult OnPost(int restaurantId)
        {
            Restaurant = restaurantData.Delete(restaurantId);
            restaurantData.Commit();

            if (Restaurant == null)
                return RedirectToPage("./NotFound");

            TempData["Message"] = $"{Restaurant.Name} has been deleted.";
            return RedirectToPage("./List");
        }
    }
}