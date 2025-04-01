using BookingRoomUniversity.Core.Base;
using System;
using System.Collections.Generic;

namespace BoookingRoomUniversity.Assignment.Repositories.Entities;

public partial class Department : BaseEntity
{
    public int DepartmentId { get; set; }


    public string Name { get; set; } = null!;

    public string? Description { get; set; }
    public int? CampusId { get; set; }
    public virtual Campus Campus { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; }
}
