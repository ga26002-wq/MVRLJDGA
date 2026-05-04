using System;
using System.Collections.Generic;
using System.Text;

namespace MVRLJDGA.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}