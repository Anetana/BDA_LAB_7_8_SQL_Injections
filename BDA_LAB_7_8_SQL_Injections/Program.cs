using BDA_LAB_7_8_SQL_Injections.Models;
using BDA_LAB_7_8_SQL_Injections.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDA_LAB_7_8_SQL_Injections
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("A safe-typed getting name.");
            var name = CustomerRepository.PromtForName();
            var customerByName = CustomerRepository.GetCustomersByNameSafe(name);
            Console.WriteLine("\tAll customers with such name: ");
            foreach (Customer customer in customerByName)
            {
                Console.WriteLine("Id: " + customer.Id + " Name: " + customer.Name + " Address: " + customer.Address);
            }


            Console.WriteLine("\n\tGetting all customers by in-band injection: ");
            var nameInBandInjection = "anna' OR 1=1 --";
            var customerByNameInBandInjection = CustomerRepository.GetCustomersByNameSqlInjection(nameInBandInjection);
            foreach (Customer customer in customerByNameInBandInjection)
            {
                Console.WriteLine("Id: " + customer.Id + " Name: " + customer.Name + " Address: " + customer.Address);
            }

            Console.WriteLine("\n\tGetting all customers by union injection: ");
            var nameUnionInjection = "anna' UNION SELECT * FROM Customer --";
            var customerByNameUnionInjection = CustomerRepository.GetCustomersByNameSqlInjection(nameUnionInjection);
            foreach (Customer customer in customerByNameUnionInjection)
            {
                Console.WriteLine("Id: " + customer.Id + " Name: " + customer.Name + " Address: " + customer.Address);
            }

        }
    }
}
