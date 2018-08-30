using Coworking.Api.Business.Models;
using Coworking.Api.DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coworking.Api.DataAccess.Mappers
{
    public static class ServiceMapper
    {

        public static ServiceEntity Map(Service dto)
        {
            return new ServiceEntity()
            {
                Active = dto.Active,
                Id = dto.Id,
                Name = dto.Name,
                Price = dto.Price
            };
        }

        public static Service Map(ServiceEntity entity)
        {
            return new Service()
            {
                Price = entity.Price,
                Name = entity.Name,
                Id = entity.Id,
                Active = entity.Active
            };
        }

    }
}
