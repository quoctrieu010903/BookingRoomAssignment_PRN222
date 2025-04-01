using BookingRoomUniversity.Core.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoookingRoomUniversity.Assignment.Repositories.Entities;

public partial class User : BaseEntity
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;


    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public int? DepartmentId { get; set; }
    public virtual Department Department { get; set; } = null!;

    public int? RoleId { get; set; }
    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<BookingCancel> BookingCancels { get; set; }

}
