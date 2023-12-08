using Hospital_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Services.IServices
{
    internal interface IRoom
    {
        Task<List<Room>> GetRoomsAsync();
        Task<Room> GetRoomByIdAsync(Guid id);
        Task<String> AddRoomAsyc(AddRoom room);
        Task<string> UpdateRoomAsync(AddRoom newRoom);
        Task<string> DeleteRoomAsync(Guid Id);
    }
}
