using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.Server.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IItemsService itemsService;

        public ProductsController(IItemsService itemsService)
        {
            this.itemsService = itemsService;
        }

        [HttpGet]
        public IActionResult Pobierz()
        {
            var items = itemsService.Get();

            return Ok(items);
        }
        
        [HttpGet("{id}", Name = "GetProductLink")]
        public IActionResult Get(int id)
        {
            var item = itemsService.Get(id);

            if (item==null)
            {
                return NotFound();
            }

            return Ok(item);
        }
      

        [HttpPost]
        public IActionResult Post([FromBody] Product item)
        {
            itemsService.Add(item);

            return CreatedAtRoute("GetProductLink", new { id = item.Id }, item);
        }
    }
}