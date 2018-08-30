using Coworking.Api.Business.Models;
using Coworking.Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coworking.Api.Mappers
{
    public static class OfficeMapper
    {

        public static Office Map(OfficeModel model)
        {

            return new Office()
            {
                Active = model.Active,
                Address = model.Address,
                City = model.City,
                HasIndividualWorkSpace = model.HasIndividualWorkSpace,
                Id = model.Id,
                IdAdmin = model.IdAdmin,
                Name = model.Name,
                NumberWorkSpaces = model.NumberWorkSpaces,
                Phone = model.Phone,
                PriceWorkSpaceDaily = model.PriceWorkSpaceDaily,
                PriceWorkSpaceMonthly = model.PriceWorkSpaceMonthly
            };

        }

    }
}
