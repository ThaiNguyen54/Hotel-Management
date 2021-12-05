using Hotel_Management_Project.Models;
using System;
using System.Data.SqlClient;

namespace Hotel_Management_Project.Service
{
    public class AccountDAO
    {
        string connectionString = @"Data Source=THAI;Initial Catalog=Hotel_Managment;Integrated Security=True";
        public bool FindAccountByUsernameAndPassword(AccountModel account)
        {
            bool success = false;
            string sqlStatement = "SELECT * FROM Account1 WHERE account_UserName = @username AND account_Password = @password";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.Add("@username", System.Data.SqlDbType.NVarChar, 100).Value = account.UserName;
                command.Parameters.Add("@password", System.Data.SqlDbType.NVarChar, 100).Value = account.PassWord;
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        success = true;
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return success;
        }
        public int InsertAccount(AccountModel account)
        {
            int newIDNumber = -1;
            string sqlStatement = "INSERT INTO Account1 (account_ID, account_UserName, account_Password) VALUES (@ID, @UserName, @Password);";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@ID", account.Id);
                command.Parameters.AddWithValue("@UserName", account.UserName);
                command.Parameters.AddWithValue("@Password", account.PassWord);
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
