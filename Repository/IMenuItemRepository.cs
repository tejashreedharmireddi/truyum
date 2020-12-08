using MenuItemService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuItemService.Repository
{
    public interface IMenuItemRepository
    {
        public IEnumerable<MenuItem> GetAll();
        public bool AddMenuItem(MenuItem item);
        public bool RemoveMenuItem(int id);
    }
}
