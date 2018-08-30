using Coworking.Api.Business.Models;
using Coworking.Api.DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coworking.Api.DataAccess.Mappers
{
    public static class RoomMapper
    {

        public static RoomEntity Map(Room dto)
        {
            return new RoomEntity()
            {
                Capacity = dto.Capacity,
                Id = dto.Id,
                Name = dto.Name
            };
        }

        public static Room Map(RoomEntity entity)
        {
            return new Room()
            {
                Id = entity.Id,
                Capacity = entity.Capacity,
                Name = entity.Name
            };
        }

    }
}
