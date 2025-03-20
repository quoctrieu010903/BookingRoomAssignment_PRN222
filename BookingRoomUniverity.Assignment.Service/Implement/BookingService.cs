
using BookingRoomUniverity.Assignment.Service.Interface;
using BoookingRoomUniversity.Assignment.Repositories.Data;
using BoookingRoomUniversity.Assignment.Repositories.Entities;

namespace BookingRoomUniverity.Assignment.Service.Implement
{
    public class BookingService :IBookingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public  async Task CreateBooking(Booking obj)
        {
            _unitOfWork.Repository<Booking>().Create(obj);
           await _unitOfWork.SaveChangesAsync();
        }

        public  async Task DeleteBooking(Booking obj)
        {
            _unitOfWork.Repository<Booking>().Delete(obj);
            await _unitOfWork.SaveChangesAsync();
        }

        public List<Booking> getAllBooking()
        {
            return _unitOfWork.Repository<Booking>().Entities.ToList();
        }

        public  async Task UpdateBooking(Booking obj)
        {
            _unitOfWork.Repository<Booking>().Update(obj);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
