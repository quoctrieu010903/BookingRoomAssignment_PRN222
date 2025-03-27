using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BoookingRoomUniversity.Assignment.Repositories.Enums;

namespace BoookingRoomUniversity.Assignment.Repositories.Entities;

public partial class Booking
{
    public int BookingId { get; set; }

    public int UserId { get; set; }  // Foreign key
    [ForeignKey("UserId")]
    public User User { get; set; }  // Navigation property

    public int RoomId { get; set; }  // Foreign key cho phòng   
    public Room Room { get; set; }

    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }

    public DateTime CreatedTime { get; set; }
    public DateTime? UpdatedTime { get; set; }
    public DateTime? DeleteTime { get; set; }
}
