using Hotel_Management_Project.Models;
using System.Collections.Generic;

namespace Hotel_Management_Project.Service
{
    public interface IReceptionistService
    {
        List<ReceptionistModel> GetAllReceptionist();
        List<ReceptionistModel> SearchReceptionist(string SearchTerms);
        ReceptionistModel GetReceptionistByID(int RoomID);
        int InsertReceptionist(ReceptionistModel receptionist);
        int DeleteReceptionist(ReceptionistModel receptionist);
        int UpdateReceptionist(ReceptionistModel receptionist);
    }
}
