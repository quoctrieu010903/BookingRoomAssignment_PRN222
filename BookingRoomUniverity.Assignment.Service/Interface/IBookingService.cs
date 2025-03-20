using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoookingRoomUniversity.Assignment.Repositories.Entities;

namespace BookingRoomUniverity.Assignment.Service.Interface
{
    public interface IBookingService
    {
        List<Booking> getAllBooking();
        Task CreateBooking(Booking obj);
        Task UpdateBooking(Booking obj);
        Task DeleteBooking(Booking obj);
    }
}
