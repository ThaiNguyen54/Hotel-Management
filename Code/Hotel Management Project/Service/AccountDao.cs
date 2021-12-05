using Hotel_Management_Project.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Management_Project.Service
{
    public class AccountDao :ConnectionDataBase
    {
        public readonly SqlConnection conn;
        public AccountDao()
        {
            conn = getConnection();
        }
        public bool isLoginSuccess(LoginModel model)
        {
            try
            {
                conn.Open();
                string sql = $"select*from Account where account_UserName='{model.Username}' and account_Password='{model.Password}'";
                SqlCommand cmd = new SqlCommand(sql, conn);
            
                using (var render = cmd.ExecuteReader())
                {
                    return render.Read() ? true : false;

                }

            }
            catch
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
         
        }
    }
}
