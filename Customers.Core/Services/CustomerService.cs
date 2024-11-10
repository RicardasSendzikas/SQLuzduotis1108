using Customers.Contracts;
using Customers.Models;
using Customers.Contracts;
using Customers.Models;
using System.Collections.Generic;

namespace Customers.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void AddCustomer(Customer customer)
        {
            _customerRepository.AddCustomer(customer);
        }

        public Customer GetCustomerById(int id)
        {
            return _customerRepository.GetCustomerById(id);
        }

        public void UpdateCustomer(Customer customer)
        {
            _customerRepository.UpdateCustomer(customer);
        }

        public void DeleteCustomer(int id)
        {
            _customerRepository.DeleteCustomer(id);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAllCustomers();
        }
    }
}