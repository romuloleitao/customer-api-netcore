using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomerApi.Models;

namespace CustomerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerContext _context;

        public CustomersController(CustomerContext context) => _context = context;

        //GET: api/customers
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            return _context.CustomerItems;
        }

        //GET: api/customers/n
        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomerItem(int id)
        {
            var customerItem = _context.CustomerItems.Find(id);

            if (customerItem == null)
            {
                return NotFound();
            }
            return customerItem;
        }

        //POST: api/customers
        [HttpPost]
        public ActionResult<Customer> PostCustomerItem(Customer customerItem)
        {
            _context.CustomerItems.Add(customerItem);
            _context.SaveChanges();

            return CreatedAtAction("GetCustomerItem", new Customer { Id = customerItem.Id }, customerItem);
        }

        //PUT: api/customers/n
        [HttpPut("{id}")]
        public ActionResult PutCustomerItem(int id, Customer customerItem)
        {
            if (id != customerItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(customerItem).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        //DELETE api/customer/n
        [HttpDelete("{id}")]
        public ActionResult<Customer> DeleteCustomerItem(int id)
        {
            var customerItem = _context.CustomerItems.Find(id);

            if (customerItem == null)
            {
                return NotFound();
            }

            _context.CustomerItems.Remove(customerItem);
            _context.SaveChanges();

            return customerItem;
        }
    }
}