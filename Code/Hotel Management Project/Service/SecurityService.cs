using Hotel_Management_Project.Models;
using System.Collections.Generic;

namespace Hotel_Management_Project.Service
{
    public class SecurityService
    {
        AccountDAO accountDAO = new AccountDAO();
        static public bool Valid;
        public bool IsValid(AccountModel account)
        {
            Valid = accountDAO.FindAccountByUsernameAndPassword(account);
            return Valid;
        }

        public bool Logout()
        {
            Valid = false;
            return Valid;
        }
    }
}
