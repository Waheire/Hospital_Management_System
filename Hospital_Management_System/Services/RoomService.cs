using Hospital_Management_System.Data;
using Hospital_Management_System.Models;
using Hospital_Management_System.Services.IServices;
using Microsoft.EntityFrameworkCore;
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

        public async Task<string> AddRoomAsync(AddRoom room)
        {
            try 
            {
                Room newRoom = new Room()
                {
                    RoomNumber = room.RoomNumber,
                    RoomType = room.RoomType,
                };
                await _context.AddAsync(newRoom);
                await _context.SaveChangesAsync();
                return "Room Added Successfully";
            } catch (Exception ex)
            {
                return $"An Error Occurred! {ex.Message}";
            }
        }

        public async Task<string> DeleteRoomAsync(Room room)
        {
            try 
            {
                _context.Remove(room);
                await _context.SaveChangesAsync();
                return "Room Successfully Deleted!";
            } catch 
            {
                return "An Error Occurred!";
            }
        }

        public async Task<Room> GetRoomByIdAsync(Guid id)
        {
            try 
            {
                var room = await _context.Rooms.FirstOrDefaultAsync(r => r.RoomId == id);
                return room;
            } catch (Exception ex)
            {
                return new Room() { };
            }
        }

        public async Task<List<Room>> GetRoomsAsync()
        {
            try 
            {
              var rooms = await _context.Rooms.ToListAsync();
                return rooms;
            } catch 
            {
                return new List<Room>();
            }
        }

        public async Task<string> UpdateRoomAsync(Guid id, AddRoom updatedRoom)
        {
            try
            {
                var room = await _context.Rooms.Where(r => r.RoomId == id).FirstOrDefaultAsync();
                room.RoomNumber = updatedRoom.RoomNumber;
                room.RoomType = updatedRoom.RoomType;
                _context.Update(room);
                await _context.SaveChangesAsync();
                return "Room Updated Successfully";
            }
            catch (Exception ex)
            {
                return $"An Error Occurred! \n{ex.Message}";
            }
        }
    }
}
