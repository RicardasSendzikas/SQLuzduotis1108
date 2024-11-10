using Customers.Models;
using Customers.Models;
using System.Collections.Generic;

namespace Customers.Contracts
{
    public interface ICustomerRepository
    {
        void AddCustomer(Customer customer);
        Customer GetCustomerById(int id);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int id);
        IEnumerable<Customer> GetAllCustomers();
    }
}