using Hotel_Management_Project.Models;
using System.Collections.Generic;

namespace Hotel_Management_Project.Service
{
    public interface ICustomerService
    {
        List<CustomerModel> GetAllCustomer();
        List<CustomerModel> SearchCustomer(string SearchTerms);
        CustomerModel GetCustomerByID(int CustomerID);
        int InsertCustomer(CustomerModel Customer);
        int DeleteCustomer(CustomerModel Customer);
        int UpdateCustomer(CustomerModel Customer);
    }
}
