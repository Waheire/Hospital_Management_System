using Hospital_Management_System.Models;
using Hospital_Management_System.Services;
using Hospital_Management_System.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Controllers
{
    public class RoomController
    {
        RoomService roomService = new RoomService();

        public async Task RoomInit()
        {
            Console.WriteLine("========================================================================");
            Console.WriteLine("========================= HMS ROOMS DASHBOARD ==========================");
            Console.WriteLine("========================================================================");
            Console.WriteLine("1. View Rooms");
            Console.WriteLine("2. Add a Room");
            Console.WriteLine("3. Update a Room");
            Console.WriteLine("4. Delete a Room");
            Console.Write("Enter your choice: ");
            var choice = Console.ReadLine();
            //convert to int
            var output = int.TryParse(choice, out int option);

            //switch
            await RedirectUser(option);
        }

        public async Task RedirectUser(int option)
        {
            switch (option)
            {
                case 1:
                    await ViewRooms();
                    break;
                case 2:
                    await AddRoomView();
                    break;
                case 3:
                    await UpdateRoomView();
                    break;
                case 4:
                    await DeleteRoomView();
                    break;
                default:
                    Console.WriteLine("Invalid Option.Please Try again");
                    await RoomInit();
                    break;
            }
        }

        private async Task UpdateRoomView()
        {
            await ViewRooms();
            Console.WriteLine("===============================================================");
            Console.WriteLine("===================== Update Room ==========================");
            Console.WriteLine("===============================================================");
            Console.WriteLine("Select Room to update by Id : ");
            var roomId = Console.ReadLine();
            Guid RoomId;
            Guid.TryParse(roomId, out RoomId);
            Console.WriteLine();
            Console.WriteLine("Enter Room Number: ");
            var roomNumber = Console.ReadLine();
            var rN = int.TryParse(roomNumber, out int RoomNumber);
            Console.WriteLine("Enter Room Type: ");
            var roomType = Console.ReadLine();

            var updatedRoom = new AddRoom() { RoomNumber = RoomNumber, RoomType = roomType };
            await UpdateRoom(RoomId, updatedRoom);
        }

        private async Task DeleteRoomView()
        {
            await ViewRooms();
            Console.WriteLine("===============================================================");
            Console.WriteLine("===================== Delete Rooms ========================");
            Console.WriteLine("===============================================================");
            Console.WriteLine("Select Room to delete by Id : ");
            var roomId = Console.ReadLine();
            Guid RoomId;
            Guid.TryParse(roomId, out RoomId);
            await DeleteRoom(RoomId);
        }

        private async Task DeleteRoom(Guid RoomId)
        {
            var room = await roomService.GetRoomByIdAsync(RoomId);
            if (room == null)
            {
                return;
                await RoomInit();

            }
            //Delete
            var response = await roomService.DeleteRoomAsync(room);
            Console.WriteLine(response);
            await RoomInit();
        }

        private async Task UpdateRoom(Guid id , AddRoom updatedRoom)
        {
            var room = await roomService.GetRoomByIdAsync(id);
            if (room == null)
            {
                return;
            }
            //Update
            var response = await roomService.UpdateRoomAsync(id,updatedRoom);
            Console.WriteLine(response);
            await RoomInit();
        }

        private async Task AddRoomView()
        {
            Console.WriteLine("===============================================================");
            Console.WriteLine("===================== Add a new Room ========================");
            Console.WriteLine("===============================================================");
            Console.WriteLine();
            Console.WriteLine("Enter Room Number: ");
            var roomNumber = Console.ReadLine();
            var res = int.TryParse(roomNumber, out int RoomNumber);
            Console.WriteLine("Enter Room Type: ");
            var roomType = Console.ReadLine();

            var newRoom = new AddRoom() { RoomNumber = RoomNumber, RoomType = roomType };
            await AddRoom(newRoom);
        }

        private async Task AddRoom(AddRoom newRoom)
        {
           var response =  await roomService.AddRoomAsync(newRoom);
            Console.WriteLine(response);
            await RoomInit();
        }

        private async Task ViewRooms()
        {
            var rooms = await roomService.GetRoomsAsync();
            Console.WriteLine($"RoomID \t\t\t\t Room Number \t Room Type ");
            foreach (var room in rooms)
            {
                Console.WriteLine($"{room.RoomId}  \t {room.RoomNumber} \t {room.RoomType}");
            }

        }
    }
}
