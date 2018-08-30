using System;
using System.Collections.Generic;
using System.Text;

namespace Coworking.Api.Business.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public float Price { get; set; }
    }
}
