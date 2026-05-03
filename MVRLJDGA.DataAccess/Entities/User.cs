using System;
using System.Collections.Generic;

namespace MVRLJDGA.Entities;

public partial class User
{
    public int Id { get; set; }

    public int RoleId { get; set; }

    public string AccountName { get; set; } = null!;

    public string? AccessKey { get; set; }

    public virtual Role Role { get; set; } = null!;
}
