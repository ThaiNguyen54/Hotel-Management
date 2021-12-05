using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Management_Project.Service
{
    public class ConnectionDataBase {

        public string connectionString = @"Data Source=DESKTOP-5BBTI02\SQLSERVER;Initial Catalog=Hotel_Managment;Integrated Security=True";
        public SqlConnection getConnection()
       {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                return conn;
            }
            catch
            {
                return null;
            }
       }
    }
}
