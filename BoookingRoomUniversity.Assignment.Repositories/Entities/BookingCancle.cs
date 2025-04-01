using BookingRoomUniversity.Core.Base;
using System;

namespace BoookingRoomUniversity.Assignment.Repositories.Entities
{
    public partial class BookingCancel : BaseEntity
    {
        public int BookingCancelId { get; set; }
        public int BookingDetailId { get; set; }
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public string Reason { get; set; } = null!;
        public DateTime CancelDate { get; set; } = DateTime.Now;

        public virtual BookingDetail BookingDetail { get; set; } = null!;
        public virtual Booking Booking { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
