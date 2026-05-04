using System;
using System.Collections.Generic;
using System.Text;

namespace MVRLJDGA.BusinessLogic.DTOs
{
    public class BookDto
    {
        public long Id { get; set; }
        public int PublisherId { get; set; }
        public string Title { get; set; } = null!;
        public decimal SalePrice { get; set; }
        public int Stock { get; set; }
    }
}