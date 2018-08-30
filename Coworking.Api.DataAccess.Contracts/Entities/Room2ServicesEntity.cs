using System;
using System.Collections.Generic;
using System.Text;

namespace Coworking.Api.DataAccess.Contracts.Entities
{
    public class Room2ServicesEntity
    {

        public int IdRoom { get; set; }
        public int IdService { get; set; }

        public virtual RoomEntity Room { get; set; }
        public virtual ServiceEntity Service { get; set; }

    }
}
