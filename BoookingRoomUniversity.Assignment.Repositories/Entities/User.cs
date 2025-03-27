﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoookingRoomUniversity.Assignment.Repositories.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime? CreatedTime { get; set; }

    public DateTime? UpdatedTime { get; set; }

    public DateTime? DeleteTime { get; set; }
    

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public int? DepartmentId { get; set; }
    public virtual Department Department { get; set; } = null!;

    public int? RoleId { get; set; }
    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
