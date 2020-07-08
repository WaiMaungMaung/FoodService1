using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
       readonly List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id=1,Name="burma pizza",Location="Burma",Cuisine=CuisineType.Indian},
                new Restaurant { Id=2,Name="Italian pizza",Location="Italian",Cuisine=CuisineType.Italian},
                new Restaurant { Id=3,Name="Mexican pizza",Location="Mexican",Cuisine=CuisineType.Mexican}
            };
                 
        }
        public Restaurant Update(Restaurant updateRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updateRestaurant.Id);
            if (restaurant != null) {
                restaurant.Name = updateRestaurant.Name;
                restaurant.Location = updateRestaurant.Location;
                restaurant.Cuisine = updateRestaurant.Cuisine;
            }
            return restaurant;
        }
        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }
        public int Commit()
        {
            return 0;
        }
        public Restaurant GetRestaurantById(int id)
        {
            return  restaurants.SingleOrDefault(r => r.Id == id);
                   
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name)|| r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }
    }
}
