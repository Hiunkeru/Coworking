using Coworking.Api.Business.Models;
using Coworking.Api.DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coworking.Api.DataAccess.Mappers
{
    public static class OfficeMapper
    {

        public static OfficeEntity Map(Office dto)
        {
            return new OfficeEntity()
            {
                Active = dto.Active,
                Address = dto.Address,
                City = dto.City,
                HasIndividualWorkSpace = dto.HasIndividualWorkSpace,
                Id = dto.Id,
                IdAdmin = dto.IdAdmin,
                Name = dto.Name,
                NumberWorkSpaces = dto.NumberWorkSpaces,
                Phone = dto.Phone,
                PriceWorkSpaceDaily = dto.PriceWorkSpaceDaily,
                PriceWorkSpaceMonthly = dto.PriceWorkSpaceMonthly
            };
        }

        public static Office Map(OfficeEntity entity)
        {
            return new Office()
            {
                PriceWorkSpaceMonthly = entity.PriceWorkSpaceMonthly,
                PriceWorkSpaceDaily = entity.PriceWorkSpaceDaily,
                Phone = entity.Phone,
                NumberWorkSpaces = entity.NumberWorkSpaces,
                Name = entity.Name,
                IdAdmin = entity.IdAdmin,
                Id = entity.Id,
                HasIndividualWorkSpace = entity.HasIndividualWorkSpace,
                Active = entity.Active,
                Address = entity.Address,
                City = entity.City
            };
        }

    }
}
