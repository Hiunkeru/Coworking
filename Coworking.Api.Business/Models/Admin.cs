using System;
using System.Collections.Generic;
using System.Text;

namespace Coworking.Api.Business.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime HireDate { get; set; }
    }
}
