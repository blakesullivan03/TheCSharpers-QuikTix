using System.Collections.Generic;
using TheCSharpers_QuikTix.Models;

namespace TheCSharpers_QuikTix.Services.Interfaces
{
    public interface ICustomerService
    {
        // Add a New Customer
        void AddCustomer(Customer customer);

        // Retrieve all customers
        List<Customer> GetAllCustomers();

        // Retrieve a Customer by ID
        Customer GetCustomerById(int id);

        // Update Customer Information
        void UpdateCustomer(Customer updatedCustomer);
    }
}