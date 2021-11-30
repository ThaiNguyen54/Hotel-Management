using Hotel_Management_Project.Models;
using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Hotel_Management_Project.Service
{
    public class CustomerDAO : ICustomerService
    {
        string ConnectionString = @"Data Source=THAI;Initial Catalog=Hotel_Managment;Integrated Security=True";
        public int DeleteCustomer(CustomerModel Customer)
        {
            int newIDNumber = -1;
            string sqlStatement = "DELETE FROM Customer Where customer_ID = @ID";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                try
                {
                    command.Parameters.AddWithValue("@ID", Customer.CustomerID);
                    connection.Open();
                    newIDNumber = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {

                }
            }
            return newIDNumber;
        }

        public List<CustomerModel> GetAllCustomer()
        {
            List<CustomerModel> FoundCustomer = new List<CustomerModel>();
            string sqlStatement = "SELECT * FROM Customer";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        FoundCustomer.Add(new CustomerModel
                        {
                            CustomerID = (int)reader[0],
                            CustomerName = (string)reader[1],
                            CustomerBirthDate = (DateTime)reader[2],
                            CustomerPhone = (string)reader[3],
                            CustomerAddress = (string)reader[4]
                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return FoundCustomer;
        }

        public CustomerModel GetCustomerByID(int CustomerID)
        {
            List<CustomerModel> FoundCustomer = new List<CustomerModel>();
            string sqlStatement = "SELECT * FROM Customer";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                //command.Parameters.AddWithValue("@ID", RoomID);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        FoundCustomer.Add(new CustomerModel
                        {
                            CustomerID = (int)reader[0],
                            CustomerName = (string)reader[1],
                            CustomerBirthDate = (DateTime)reader[2],
                            CustomerPhone = (string)reader[3],
                            CustomerAddress = (string)reader[4]
                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            for (int i = 0; i < FoundCustomer.Count; i++)
            {
                if (FoundCustomer[i].CustomerID == CustomerID)
                {
                    return FoundCustomer[i];
                }
            }
            return FoundCustomer[0];
        }

        public int InsertCustomer(CustomerModel Customer)
        {
            int newIDNumber = -1;
            string sqlStatement = "INSERT INTO Customer (customer_ID, customer_Name, customer_BirthDate, customer_PhoneNumber, customer_Address) VALUES (@ID, @Name, @BirthDay, @Phone, @Address);";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@ID", Customer.CustomerID);
                command.Parameters.AddWithValue("@Name", Customer.CustomerName);
                command.Parameters.AddWithValue("@BirthDay", Customer.CustomerBirthDate);
                command.Parameters.AddWithValue("@Phone", Customer.CustomerPhone);
                command.Parameters.AddWithValue("@Address", Customer.CustomerAddress);

                try
                {
                    connection.Open();
                    newIDNumber = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {

                }
            }
            return newIDNumber;
        }

        public List<CustomerModel> SearchCustomer(string SearchTerms)
        {
            throw new System.NotImplementedException();
        }

        public int UpdateCustomer(CustomerModel Customer)
        {
            int newIDNumber = -1;
            string sqlStatement = "UPDATE Customer SET customer_Name = @Name, customer_BirthDate = @BirthDay, customer_PhoneNumber = @Phone, customer_Address = @Address WHERE customer_ID = @ID";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Name", Customer.CustomerName);
                command.Parameters.AddWithValue("@BirthDay", Customer.CustomerBirthDate);
                command.Parameters.AddWithValue("@Phone", Customer.CustomerPhone);
                command.Parameters.AddWithValue("@Address", Customer.CustomerAddress);
                command.Parameters.AddWithValue("@ID", Customer.CustomerID);
                try
                {
                    connection.Open();
                    newIDNumber = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {

                }
            }
            return newIDNumber;
        }
    }
}
