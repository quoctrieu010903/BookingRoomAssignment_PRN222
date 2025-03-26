﻿using System;
using System.Collections.Generic;
using BoookingRoomUniversity.Assignment.Repositories.Enums;

namespace BoookingRoomUniversity.Assignment.Repositories.Entities;

public partial class Department
{
    public int DepartmentId { get; set; }

    public int CampusId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DepartmentStatus? Status { get; set; }

    public DateTime? CreatedTime { get; set; }

    public DateTime? UpdatedTime { get; set; }

    public DateTime? DeleteTime { get; set; }

    public virtual Campus Campus { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
