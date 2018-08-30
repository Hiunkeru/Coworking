using System;
using System.Collections.Generic;
using System.Text;

namespace Coworking.Api.Business.Models
{
    public class Office
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public bool Active { get; set; }
        public int IdAdmin { get; set; }
        public bool HasIndividualWorkSpace { get; set; }
        public int NumberWorkSpaces { get; set; }
        public float PriceWorkSpaceDaily { get; set; }
        public float PriceWorkSpaceMonthly { get; set; }
    }
}
