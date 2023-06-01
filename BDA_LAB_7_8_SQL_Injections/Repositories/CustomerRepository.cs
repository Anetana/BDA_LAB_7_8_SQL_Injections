using BDA_LAB_7_8_SQL_Injections.Connection_helper;
using BDA_LAB_7_8_SQL_Injections.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDA_LAB_7_8_SQL_Injections.Repositories
{
    internal class CustomerRepository
    {
        public static List<Customer> GetCustomersByNameSafe(string name)
        {
            var customers = new List<Customer>();
            using (SqlConnection cnn = new SqlConnection(Connection.GetConnectionString()))
            {
                string queryGetCustomerByName = $"SELECT * FROM Customer WHERE name = @Name";

                using (SqlCommand getCustomerByName = new SqlCommand(queryGetCustomerByName, cnn))
                {
                    getCustomerByName.Parameters.Add(new SqlParameter("@Name", name));
                    cnn.Open();
                    using (SqlDataReader reader = getCustomerByName.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customers.Add(new Customer { Id = Convert.ToInt32(reader[0]), Name = reader[1].ToString(), Address = reader[2].ToString() });
                        }
                    }
                }
            }

            return customers;

        }

        public static List<Customer> GetCustomersByNameSqlInjection(string Name)
        {
            var customers = new List<Customer>();
            using (SqlConnection cnn = new SqlConnection(Connection.GetConnectionString()))
            {
                string queryGetCustomerByName = $"SELECT * FROM Customer WHERE name = '{Name}'";

                using (SqlCommand getCustomerByName = new SqlCommand(queryGetCustomerByName, cnn))
                {
                    cnn.Open();
                    using (SqlDataReader reader = getCustomerByName.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customers.Add(new Customer { Id = Convert.ToInt32(reader[0]), Name = reader[1].ToString(), Address = reader[2].ToString() });
                        }
                    }
                }
            }

            return customers;

        }

        public static List<Customer> GetAllCustomers()
        {
            var customers = new List<Customer>();
            string queryGetAllCustomers = "SELECT * FROM Customer";
            using (SqlConnection cnn = new SqlConnection(Connection.GetConnectionString()))
            {
                using (SqlCommand GetAllCustomers = new SqlCommand(queryGetAllCustomers, cnn))
                {
                    cnn.Open();
                    using (var reader = GetAllCustomers.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customers.Add(new Customer { Id = Convert.ToInt32(reader[0]), Name = reader[1].ToString(), Address = reader[2].ToString() });
                        }
                    }
                }
            }
            return customers;
        }

        internal static string PromtForName()
        {
            Console.Write("Enter the name of a customer: ");
            string name = Console.ReadLine();
            return name;
        }
    }
}
