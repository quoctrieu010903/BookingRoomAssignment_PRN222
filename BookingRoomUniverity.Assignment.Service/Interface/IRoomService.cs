using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoookingRoomUniversity.Assignment.Repositories.Entities;

namespace BookingRoomUniverity.Assignment.Service.Interface
{
    public interface IRoomService
    {
        List<Room> getAllRoom();
        Task CreateRoom(Room obj);
        Task UpdateRoom(Room obj);
        Task DeleteRoom(Room obj);
    }
}
