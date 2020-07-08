using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;
namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantByName(String Name);
        Restaurant GetRestaurantById(int id);
        Restaurant Update(Restaurant updatedRestaurant);
       
        Restaurant Add(Restaurant newRestaurant);

        Restaurant Delete(int id);
        int Commit();
    } 
}
