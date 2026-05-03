using System;
using System.Collections.Generic;

namespace MVRLJDGA.Entities;

public partial class Book
{
    public long Id { get; set; }

    public int PublisherId { get; set; }

    public string Title { get; set; } = null!;

    public decimal? SalePrice { get; set; }

    public int? Stock { get; set; }

    public virtual Publisher Publisher { get; set; } = null!;
}
