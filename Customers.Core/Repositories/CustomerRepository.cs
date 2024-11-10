using Customers.Models;
using Customers.Contracts;
using Customers.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace Customers.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly string _connectionString;

        public CustomerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddCustomer(Customer customer)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sql = "INSERT INTO Customers (FirstName, LastName, Email, PhoneNumber) VALUES (@FirstName, @LastName, @Email, @PhoneNumber)";
                db.Execute(sql, new { customer.FirstName, customer.LastName, customer.Email, customer.PhoneNumber });
            }
        }

        public Customer GetCustomerById(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.QueryFirstOrDefault<Customer>("SELECT * FROM Customers WHERE Id = @Id", new { Id = id });
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sql = "UPDATE Customers SET FirstName = @FirstName, LastName = @LastName, Email = @Email, PhoneNumber = @PhoneNumber WHERE Id = @Id";
                db.Execute(sql, new { customer.FirstName, customer.LastName, customer.Email, customer.PhoneNumber, customer.Id });
            }
        }

        public void DeleteCustomer(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sql = "DELETE FROM Customers WHERE Id = @Id";
                db.Execute(sql, new { Id = id });
            }
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Customer>("SELECT * FROM Customers");
            }
        }
    }
}