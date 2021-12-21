using System;
using System.Collections.Generic;

#nullable disable

namespace Practice_API.Models
{
    public partial class Employee
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
    }
}
