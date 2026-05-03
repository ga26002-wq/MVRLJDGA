using System;
using System.Collections.Generic;

namespace MVRLJDGA.Entities;

public partial class Publisher
{
    public int Id { get; set; }

    public string PublisherName { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
