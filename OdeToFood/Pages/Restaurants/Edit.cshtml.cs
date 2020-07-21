using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Restaurant Restaurants { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }
        public EditModel(IRestaurantData restaurantData,IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? restaurantId)
        {

            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            if (restaurantId.HasValue) { 
            Restaurants = restaurantData.GetRestaurantById(restaurantId.Value);
            }
            else
            {
                Restaurants = new Restaurant();
            }
            if (Restaurants == null)
            {
              return  RedirectToPage("./NotFound");
            }
            return Page();
        }
        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)//Checking for Input Validation
            {
                Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();

                return Page();
                
            }
            if (Restaurants.Id > 0)
            {
                restaurantData.Update(Restaurants);
            }
            else
            {
                restaurantData.Add(Restaurants);
            }
            TempData["Message"] = "Saved Restaurant";
            restaurantData.Commit();
             return RedirectToPage("./Detail", new { restaurantId = Restaurants.Id });
            //return RedirectToPage("./List");
        }
    }
}
