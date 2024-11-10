using System;
using System.Collections.Generic;
using Customers.Contracts;
using Customers.Models;
using Customers.Models;
using Customers.Repositories;
using Customers.Services;

namespace CustomersApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=localhost;Database=SQLuzduotis1108;Trusted_Connection=True;TrustServerCertificate=true;";

            ICustomerRepository customerRepository = new CustomerRepository(connectionString);
            CustomerService customerService = new CustomerService(customerRepository);

            while (true)
            {
                Console.WriteLine("Pasirinkite veiksmą:");
                Console.WriteLine("1. Pridėti klientą");
                Console.WriteLine("2. Gauti klientą pagal ID");
                Console.WriteLine("3. Atnaujinti kliento informaciją");
                Console.WriteLine("4. Pašalinti klientą");
                Console.WriteLine("5. Gauti visų klientų sąrašą");
                Console.WriteLine("6. Išeiti");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // Pridėti klientą
                        var newCustomer = new Customer();
                        Console.Write("Vardas: ");
                        newCustomer.FirstName = Console.ReadLine();
                        Console.Write("Pavardė: ");
                        newCustomer.LastName = Console.ReadLine();
                        Console.Write("El. paštas: ");
                        newCustomer.Email = Console.ReadLine();
                        Console.Write("Telefono numeris: ");
                        newCustomer.PhoneNumber = Console.ReadLine();
                        customerService.AddCustomer(newCustomer);
                        Console.WriteLine("Klientas pridėtas.");
                        break;

                    case "2":
                        // Gauti klientą pagal ID
                        Console.Write("Įveskite kliento ID: ");
                        int idToGet = int.Parse(Console.ReadLine());
                        var customer = customerService.GetCustomerById(idToGet);
                        if (customer != null)
                        {
                            Console.WriteLine($"Id: {customer.Id}, Vardas: {customer.FirstName}, Pavardė: {customer.LastName}, El. paštas: {customer.Email}, Telefonas: {customer.PhoneNumber}");
                        }
                        else
                        {
                            Console.WriteLine("Klientas nerastas.");
                        }
                        break;

                    case "3":
                        // Atnaujinti kliento informaciją
                        Console.Write("Įveskite kliento ID, kurį norite atnaujinti: ");
                        int idToUpdate = int.Parse(Console.ReadLine());
                        var customerToUpdate = customerService.GetCustomerById(idToUpdate);
                        if (customerToUpdate != null)
                        {
                            Console.Write("Naujas Vardas: ");
                            customerToUpdate.FirstName = Console.ReadLine();
                            Console.Write("Nauja Pavardė: ");
                            customerToUpdate.LastName = Console.ReadLine();
                            Console.Write("Naujas El. paštas: ");
                            customerToUpdate.Email = Console.ReadLine();
                            Console.Write("Naujas Telefono numeris: ");
                            customerToUpdate.PhoneNumber = Console.ReadLine();
                            customerService.UpdateCustomer(customerToUpdate);
                            Console.WriteLine("Kliento informacija atnaujinta.");
                        }
                        else
                        {
                            Console.WriteLine("Klientas nerastas.");
                        }
                        break;

                    case "4":
                        // Pašalinti klientą
                        Console.Write("Įveskite kliento ID, kurį norite pašalinti: ");
                        int idToDelete = int.Parse(Console.ReadLine());
                        customerService.DeleteCustomer(idToDelete);
                        Console.WriteLine("Klientas pašalintas.");
                        break;

                    case "5":
                        // Gauti visų klientų sąrašą
                        var customers = customerService.GetAllCustomers();
                        Console.WriteLine("Visi klientai:");
                        foreach (var customerItem in customers)
                        {
                            Console.WriteLine($"Id: {customerItem.Id}, Vardas: {customerItem.FirstName}, Pavardė: {customerItem.LastName}, El. paštas: {customerItem.Email}, Telefonas: {customerItem.PhoneNumber}");
                        }
                        break;

                    case "6":
                        return; // Išeiti

                    default:
                        Console.WriteLine("Neteisingas pasirinkimas, bandykite dar kartą.");
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}