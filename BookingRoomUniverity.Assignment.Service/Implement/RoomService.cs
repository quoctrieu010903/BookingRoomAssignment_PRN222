using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingRoomUniverity.Assignment.Service.Interface;
using BoookingRoomUniversity.Assignment.Repositories.Data;
using BoookingRoomUniversity.Assignment.Repositories.Entities;

namespace BookingRoomUniverity.Assignment.Service.Implement
{
    public class RoomService : IRoomService
    {
        private IUnitOfWork _unitOfWork;

        public RoomService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public  async Task CreateRoom(Room obj)
        {
            _unitOfWork.Repository<Room>().Create(obj);
           await _unitOfWork.SaveChangesAsync();
        }

        public  async Task DeleteRoom(Room obj)
        {
            _unitOfWork.Repository<Room>().Delete(obj);
            await _unitOfWork.SaveChangesAsync();
        }

        public List<Room> getAllRoom()
        {
            return _unitOfWork.Repository<Room>().Entities.ToList();
        }

        public  async Task UpdateRoom(Room obj)
        {
            _unitOfWork.Repository<Room>().Update(obj);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
