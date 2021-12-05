using Hotel_Management_Project.Models;
using System;
using System.Data.SqlClient;

namespace Hotel_Management_Project.Service
{
    public class ReceiptDAO
    {
        string ConnectionString = @"Data Source=THAI;Initial Catalog=Hotel_Managment;Integrated Security=True";
        public int InsertReceipt(ReceiptModel receipt)
        {
            int newIDNumber = -1;
            string sqlStatement = "INSERT INTO Receipt1 (receipt_ID, customer_Name, customer_ID, totalCost, date) VALUES (@ID, @CusName, @CusID, @Cost, @date);";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@ID", receipt.ReceiptId);
                command.Parameters.AddWithValue("@CusName", receipt.CustomerName);
                command.Parameters.AddWithValue("@CusID", receipt.CustomerID);
                command.Parameters.AddWithValue("@Cost", receipt.TotalCost);
                command.Parameters.AddWithValue("@date", receipt.date);
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
