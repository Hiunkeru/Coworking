using Coworking.Api.Business.Models;
using Coworking.Api.DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coworking.Api.DataAccess.Mappers
{
    public static class AdminMapper
    {

        public static AdminEntity Map(Admin dto)
        {
            return new AdminEntity()
            {
                Email = dto.Email,
                Id = dto.Id,
                Name = dto.Name,
                Phone = dto.Phone
            };
        }

        public static Admin Map(AdminEntity entity)
        {
            return new Admin()
            {
                Email = entity.Email,
                Id = entity.Id,
                Name = entity.Name,
                Phone = entity.Phone
            };
        }

    }
}
