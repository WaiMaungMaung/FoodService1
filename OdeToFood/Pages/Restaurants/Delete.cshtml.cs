﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        public Restaurant Restaurant { get; set; }
        public DeleteModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public IActionResult OnGet(int RestaurantId)
        {
            Restaurant = restaurantData.GetRestaurantById(RestaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();

        }
        public IActionResult OnPost(int RestaurantId)
        {
            var restaurant = restaurantData.Delete(RestaurantId);
            restaurantData.Commit();
            if (restaurant == null)
            {
                return RedirectToPage("./NotFound");

            }
            TempData["Message"] = $"{restaurant.Name} Deleted";
            return RedirectToPage("./List");

        }
    }
}