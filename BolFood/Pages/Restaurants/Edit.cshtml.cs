using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BolFood.core;
using BolFood.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BolFood
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;
        private readonly IHtmlHelper _htmlHelper;
        
        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }
        public EditModel(IRestaurantData restaurantData
            ,IHtmlHelper htmlHelper)
        {
            _restaurantData = restaurantData;
            _htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? restaurantId)
        {
            if (restaurantId.HasValue)
            {
                Restaurant = _restaurantData.GetRestaurantById(restaurantId.Value);
            }
            else
            {
                Restaurant = new Restaurant();
            }
            Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
            if (Restaurant == null)
                return RedirectToPage("./NotFound");

            return Page();
        }

        public IActionResult OnPost()
        {
            Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
            if (!ModelState.IsValid)
                return Page();

            if (Restaurant.Id > 0)
                Restaurant = _restaurantData.Update(Restaurant);
            else
                Restaurant = _restaurantData.Add(Restaurant);

            _restaurantData.Commit();
            TempData["Message"] = "Restaurant Saved";
            return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id });
        }

    }
}