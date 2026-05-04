using System;
using System.Collections.Generic;
using System.Text;

namespace MVRLJDGA.Entities
{
    public class Publisher
    {
        public int Id { get; set; }
        public string PublisherName { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}