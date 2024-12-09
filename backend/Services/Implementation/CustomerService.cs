/*using System.Collections.Generic;
using System.Linq;
using TheCSharpers_QuikTix.Services.Interfaces;
using TheCSharpers_QuikTix.Models;
public class CustomerService : ICustomerService
{
    private List<Customer> customers;

    private StorageService storageAccess;

    // Constructor
    public CustomerService(StorageService storageService)
    {
        storageAccess = storageService;
        customers = storageAccess.ReadCustomers();
    }

    // Add a New Customer
    public void AddCustomer(Customer customer)
    {
        customers.Add(customer);
    }

    // Retrieve all customers
    public List<Customer> GetAllCustomers()
    {
        return customers;
    }

    // Retrieve a Customer by ID
    public Customer GetCustomerById(int id)
    {
        var customer = customers.FirstOrDefault(c => c.Id == id);
        if (customer == null)
        {
            throw new KeyNotFoundException($"Customer with ID {id} not found.");
        }
        return customer;
    }

    // Update Customer Information
    public void UpdateCustomer(Customer updatedCustomer)
    {
        var customer = GetCustomerById(updatedCustomer.Id);
        if (customer != null)
        {
            customer.Name = updatedCustomer.Name;
            customer.Email = updatedCustomer.Email;
            customer.PhoneNumber = updatedCustomer.PhoneNumber;
        }
    }
}*/