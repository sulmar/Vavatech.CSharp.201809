using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.Server.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly ICustomersService customersService;

        public CustomersController(ICustomersService customersService)
        {
            this.customersService = customersService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await customersService.GetAsync());
        }
        


        [HttpGet("{id}", Name ="GetCustomerLink")]
        public IActionResult Get(int id)
        {
            var customer = customersService.Get(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }


        [HttpGet("{id}/HomeAddress")]
        public IActionResult GetHomeAddress(int id)
        {
            var address = new Address();

            return Ok(address);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            customersService.Add(customer);

            return CreatedAtRoute("GetCustomerLink", new { id = customer.Id }, customer);
        }
    }
}
