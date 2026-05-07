using System;
using System.Collections.Generic;
using System.Text;

namespace MVRLJDGA.Entities
{
    public class Book
    {
        public long Id { get; set; }
        public int PublisherId { get; set; }

        public string? Title { get; set; }

        public decimal SalePrice { get; set; }
        public int Stock { get; set; }
        public string? ImageUrl { get; set; }
  
        public virtual Publisher Publisher { get; set; } = null!;
    }
}