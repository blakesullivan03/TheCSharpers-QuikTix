using Microsoft.AspNetCore.Mvc;
using TheCSharpers_QuikTix.Models;
using System.Collections.Generic;
using System.Linq;

namespace TheCSharpers_QuikTix.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
    
        private readonly QuikTixDbContext _context;
        
        public CustomerController(QuikTixDbContext context)
        {
            _context = context;
        }

        // GET: api/Customer/GetAllCustomers
        [HttpGet("GetAllCustomers")]
        public ActionResult<IEnumerable<Customer>> GetAllCustomers()
        {
            return Ok(_context.Customers.ToList());
        }

        // GET: api/Customer/GetCustomerByID/{id}
        [HttpGet("GetCustomerByID/{id}")]
        public ActionResult<Customer> GetCustomerById(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.CustomerId == id);
            if (customer == null)
            {
                return NotFound($"Customer with ID {id} not found.");
            }
            return Ok(customer);
        }

        // POST: api/Customer
        [HttpPost("CreateCustomerAccount")]
        public ActionResult<Customer> CreateCustomer([FromBody] Customer newCustomer)
        {
            if (newCustomer == null || string.IsNullOrEmpty(newCustomer.Name))
            {
                return BadRequest("Invalid customer data.");
            }
            newCustomer.CustomerId = _context.Customers.Count() > 0 ? _context.Customers.Max(c => c.CustomerId) + 1 : 1;
            _context.Customers.Add(newCustomer);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCustomerById), new { id = newCustomer.CustomerId }, newCustomer);
        }

        // DELETE: api/Customer/DeleteCustomer/{id}
        [HttpDelete("DeleteCustomer/{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.CustomerId == id);
            if (customer == null)
            {
                return NotFound($"Customer with ID {id} not found.");
            }
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
