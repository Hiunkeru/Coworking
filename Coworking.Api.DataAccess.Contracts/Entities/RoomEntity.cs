using System;
using System.Collections.Generic;
using System.Text;

namespace Coworking.Api.DataAccess.Contracts.Entities
{
    public class RoomEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public virtual ICollection<Offices2RoomsEntity> Office2Room { get; set; }
        public virtual ICollection<Room2ServicesEntity> Room2Service { get; set; }
        
    }
}
