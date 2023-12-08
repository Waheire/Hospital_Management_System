using Hospital_Management_System.Data;
using Hospital_Management_System.Models;
using Hospital_Management_System.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Services
{
    public class RoomService : IRoom
    {
        private readonly AppDbContext _context;

        public RoomService()
        {
            _context = new AppDbContext();
        }


        public Task<string> AddRoomAsyc(AddRoom room)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteRoomAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<Room> GetRoomByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Room>> GetRoomsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateRoomAsync(AddRoom newRoom)
        {
            throw new NotImplementedException();
        }
    }
}
