using System;
using System.Collections.Generic;
using System.Text;

namespace Coworking.Api.DataAccess.Contracts.Entities
{
    public class BookingEntity
    {

        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime CreateDate { get; set; }
        public int OfficeId { get; set; }
        public bool RentWorkSpace { get; set; }
        public int? RoomId { get; set; }

        public virtual UserEntity User { get; set; }
        public virtual OfficeEntity Office { get; set; }
    }
}
