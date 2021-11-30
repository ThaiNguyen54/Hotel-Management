using Hotel_Management_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Hotel_Management_Project.Service
{
    public class ReceptionistDAO : IReceptionistService
    {
        string ConnectionString = @"Data Source=THAI;Initial Catalog=Hotel_Managment;Integrated Security=True";

        public int DeleteReceptionist(ReceptionistModel receptionist)
        {
            int newIDNumber = -1;
            string sqlStatement = "DELETE FROM Receptionist Where ReceptionistID = @ID";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                try
                {
                    command.Parameters.AddWithValue("@ID", receptionist.ReceptionistId);
                    connection.Open();
                    newIDNumber = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {

                }
            }
            return newIDNumber;
        }

        public List<ReceptionistModel> GetAllReceptionist()
        {
            List<ReceptionistModel> FoundReceptionists = new List<ReceptionistModel>();
            string sqlStatement = "SELECT * FROM Receptionist";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        FoundReceptionists.Add(new ReceptionistModel
                        {
                            ReceptionistId  = (int)reader[0],
                            ReceptionistName = (string)reader[1],
                            ReceptionistBirthDay = (DateTime)reader[2],
                            ReceptionistPhone = (string)reader[3],
                            ReceptionistAddress = (string)reader[4]
                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return FoundReceptionists;
        }

        public ReceptionistModel GetReceptionistByID(int receptionistID)
        {
            List<ReceptionistModel> FoundReceptionist = new List<ReceptionistModel>();
            string sqlStatement = "SELECT * FROM Receptionist";

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
                        FoundReceptionist.Add(new ReceptionistModel
                        {
                            ReceptionistId = (int)reader[0],
                            ReceptionistName = (string)reader[1],
                            ReceptionistBirthDay = (DateTime)reader[2],
                            ReceptionistPhone = (string)reader[3],
                            ReceptionistAddress = (string)reader[4]
                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            for (int i = 0; i < FoundReceptionist.Count; i++)
            {
                if (FoundReceptionist[i].ReceptionistId == receptionistID)
                {
                    return FoundReceptionist[i];
                }
            }
            return FoundReceptionist[0];
        }

        public int InsertReceptionist(ReceptionistModel receptionist)
        {
            int newIDNumber = -1;
            string sqlStatement = "INSERT INTO Receptionist (ReceptionistID, ReceptionistName, ReceptionistBirthDay, ReceptionistPhone, ReceptionistAddress) VALUES (@ID, @Name, @BirthDay, @Phone, @Address);";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@ID", receptionist.ReceptionistId);
                command.Parameters.AddWithValue("@Name", receptionist.ReceptionistName);
                command.Parameters.AddWithValue("@BirthDay", receptionist.ReceptionistBirthDay);
                command.Parameters.AddWithValue("@Phone", receptionist.ReceptionistPhone);
                command.Parameters.AddWithValue("@Address", receptionist.ReceptionistAddress);

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

        public List<ReceptionistModel> SearchReceptionist(string SearchTerms)
        {
            throw new System.NotImplementedException();
        }

        public int UpdateReceptionist(ReceptionistModel receptionist)
        {
            int newIDNumber = -1;
            string sqlStatement = "UPDATE Receptionist SET ReceptionistName = @Name, ReceptionistBirthday = @BirthDay, ReceptionistPhone = @Phone, ReceptionistAddress = @Address WHERE ReceptionistID = @ID";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Name", receptionist.ReceptionistName);
                command.Parameters.AddWithValue("@BirthDay", receptionist.ReceptionistBirthDay);
                command.Parameters.AddWithValue("@Phone", receptionist.ReceptionistPhone);
                command.Parameters.AddWithValue("@Address", receptionist.ReceptionistAddress);
                command.Parameters.AddWithValue("@ID", receptionist.ReceptionistId);
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
