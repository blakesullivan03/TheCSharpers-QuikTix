using System.Collections.Generic;
using System.Linq;
using TheCSharpers_QuikTix.Services.Interfaces;
using TheCSharpers_QuikTix.Models;
public class CustomerService : ICustomerService
{
    private readonly QuikTixDbContext _context;

    public CustomerService(QuikTixDbContext context)
    {
        _context = context;
    }

    // Add a New Customer
    public void AddCustomer(Customer customer)
    {
        _context.Add(customer);
    }

    //Retrieve all Customers
    public List<Customer> GetAllCustomers()
    {
        return _context.Customers.ToList();
    }

    // Retrieve a Customer by ID
    public Customer GetCustomerById(int id)
    {
        var customer = _context.Customers.FirstOrDefault(c => c.CustomerId == id);
        if (customer == null)
        {
            throw new KeyNotFoundException($"Customer with ID {id} not found.");
        }
        return customer;
    }

    // Update Customer Information
    public void UpdateCustomer(Customer updatedCustomer)
    {
        var customer = GetCustomerById(updatedCustomer.CustomerId);
        if (customer != null)
        {
            customer.Name = updatedCustomer.Name;
            customer.Email = updatedCustomer.Email;
            customer.PhoneNumber = updatedCustomer.PhoneNumber;
        }
    }

    // Delete a Customer
    public void DeleteCustomer(int id)
    {
        var customer = GetCustomerById(id);
        if (customer != null)
        {
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
    }
}