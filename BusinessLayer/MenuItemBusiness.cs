using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class MenuItemBusiness
    {
        readonly MenuItemRepository menuItemRepository = new MenuItemRepository();

        public List<MenuItem> GetMenuItems(decimal min, decimal max)
        {
            return menuItemRepository.GetAllMenuItems().Where(item => item.Price > min && item.Price < max).ToList();
            
            //return menuItemRepository.GetallItems().OrderByDescending(item => item.price).toList();
        }

        public List<MenuItem> GetMenuItems()
        {
            return menuItemRepository.GetAllMenuItems().ToList();

        }

        public bool InsertMenuItem(MenuItem menuItem)
        {
            return menuItemRepository.InsertMenuItem(menuItem) != 0;
        }
    }
}