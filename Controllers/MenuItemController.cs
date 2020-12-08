using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MenuItemService.Models;
using MenuItemService.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MenuItemService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class MenuItemController : ControllerBase
    {
        private IMenuItemRepository repository;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(MenuItemController));
        public MenuItemController(IMenuItemRepository repository)
        {
            this.repository = repository;
        }
        [HttpPost]
        public IActionResult AddMenuItem([FromBody]MenuItem item)
        {
            try
            {
                _log4net.Info("Adding menu item with id "+ item.Id);
                repository.AddMenuItem(item);
                return Ok(item);
            }
            catch
            {
                _log4net.Error("Failed to add menu item with id:" + item.Id + "name: " + item.Name);
                return new BadRequestResult();
            }
        }
        [HttpGet]
        public IActionResult GetAllMenuItems()
        {
            try
            {
                _log4net.Info("Getting all menu items");
                var list=repository.GetAll().ToList();
                return Ok(list);
            }
            catch
            {
                _log4net.Error("Failed to get menu items");
                return new  NoContentResult();
            }
        }
        [HttpDelete]
        public IActionResult RemoveMenuItem(int id)
        {
            try
            {
                _log4net.Info("Removing menu item with id " + id);
                repository.RemoveMenuItem(id);
                return Ok();
            }
            catch
            {
                _log4net.Error("Failed to delete menu item with id:" + id );
                return new BadRequestResult();
            }
        }
    }
}