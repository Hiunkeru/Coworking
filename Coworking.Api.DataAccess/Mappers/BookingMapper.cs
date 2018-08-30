using Coworking.Api.Business.Models;
using Coworking.Api.DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coworking.Api.DataAccess.Mappers
{
    public static class BookingMapper
    {

        public static BookingEntity Map(Booking dto)
        {
            return new BookingEntity()
            {
                BookingDate = dto.BookingDate,
                CreateDate = dto.CreateDate,
                Id = dto.Id,
                OfficeId = dto.OfficeId,
                RentWorkSpace = dto.RentWorkSpace,
                RoomId = dto.RoomId,
                UserId = dto.UserId
            };
        }

        public static Booking Map(BookingEntity entity)
        {
            return new Booking()
            {
                UserId = entity.UserId,
                RoomId = entity.RoomId,
                RentWorkSpace = entity.RentWorkSpace,
                OfficeId = entity.OfficeId,
                Id = entity.Id,
                CreateDate = entity.CreateDate,
                BookingDate = entity.BookingDate
            };
        }

    }
}
