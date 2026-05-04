using System;
using System.Collections.Generic;
using System.Text;

namespace MVRLJDGA.Entities
{
    public class User
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string AccountName { get; set; }
        public string AccessKey { get; set; }
        public Role Role { get; set; }
    }
}