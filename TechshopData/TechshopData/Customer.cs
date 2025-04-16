
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechshopData.data
{
    internal class Customer
    {
        public int CustomerID { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public Customer(string firstName, string lastName, string email, string phone, string address)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Address = address;
        }

        public void Register(DataConnector dbConnector)
        {
            try
            {
                dbConnector.OpenConnection();
                var command = new SqlCommand("INSERT INTO Customers (FirstName, LastName, Email, Phone, Address) VALUES (@FirstName, @LastName, @Email, @Phone, @Address)", dbConnector.GetConnection());
                command.Parameters.AddWithValue("@FirstName", FirstName);
                command.Parameters.AddWithValue("@LastName", LastName);
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@Phone", Phone);
                command.Parameters.AddWithValue("@Address", Address);

                command.ExecuteNonQuery();
            }
            catch (SqlException ex) when (ex.Number == 2627) // Unique constraint violation  
            {
                throw new InvalidOperationException("A customer with this email already exists.");
            }
            finally
            {
                dbConnector.CloseConnection();
            }
        }
    }
}
