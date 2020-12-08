using MenuItemService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuItemService.Repository
{
    public class MenuItemRepository : IMenuItemRepository
    {
        /*List<Category> category = new List<Category>()
        {
            new Category(){Id=1, Name="Main Course"},
            new Category(){Id=2, Name="Starter"},
            new Category(){Id=3, Name="Dessert"}
        };*/
        static List<MenuItem> menuItems = new List<MenuItem>()
        {
            new MenuItem(){Id=1,Name="sandwich ",Price=200,Active=true,DateOfLaunch=DateTime.Parse("03/15/2017"),FreeDelivery=true,CategoryName="Main Course"},
            new MenuItem(){Id=2,Name="Burger",Price=350,Active=true,DateOfLaunch=DateTime.Parse("12/23/2017"),FreeDelivery=false,CategoryName="Main Course"},
            new MenuItem(){Id=3,Name="Pizza",Price=150,Active=true,DateOfLaunch=DateTime.Parse("08/21/2017"),FreeDelivery=false,CategoryName="Main course"},
            new MenuItem(){Id=4,Name="French Fries",Price=300,Active=false,DateOfLaunch=DateTime.Parse("07/02/2017"),FreeDelivery=true,CategoryName="Starter"},
            new MenuItem(){Id=5,Name="Chocolate Brownie",Price=300,Active=true,DateOfLaunch=DateTime.Parse("11/01/2020"),FreeDelivery=true,CategoryName="Dessert"}
        };
        public bool AddMenuItem(MenuItem item)
        {
            var duplicate = menuItems.SingleOrDefault(x => x.Id == item.Id);
            if (duplicate == null)
            {
                menuItems.Add(item);
                return true;
            }
            return false;
        }

        public IEnumerable<MenuItem> GetAll()
        {
            var items=menuItems.ToList();
            return items;
        }

        public bool RemoveMenuItem(int id)
        {
            var itemToRemove = menuItems.SingleOrDefault(x => x.Id == id);
            if (itemToRemove != null)
            {
                menuItems.Remove(itemToRemove);
                return true;
            }
            return false;    
        }
    }
}
