using System;
using System.Collections.Generic;

namespace MVRLJDGA.Entities;

public partial class Role
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
