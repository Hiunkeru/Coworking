using Coworking.Api.Business.Models;
using Coworking.Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coworking.Api.Mappers
{
    public static class RoomMapper
    {

        public static Room Map(RoomModel model)
        {

            return new Room()
            {
                Capacity = model.Capacity,
                Id = model.Id,
                Name = model.Name
            };

        }

    }
}
