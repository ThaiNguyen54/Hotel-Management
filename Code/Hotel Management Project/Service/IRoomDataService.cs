using Hotel_Management_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Management_Project.Service
{
    interface IRoomDataService
    {
        List<RoomModel> GetAllRoom();
        List<RoomModel> SearchRoom(string SearchTerms);
        RoomModel GetRoomByID(int RoomID);
        int InsertRoom(RoomModel room);
        int DeleteRoom(RoomModel room);
        int UpdateRoom(RoomModel room);
    }
}
