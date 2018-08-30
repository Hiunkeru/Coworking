using Coworking.Api.DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Coworking.Api.DataAccess.Contracts.Repositories
{
    public interface IBookingRepository : IRepository<BookingEntity>
    {
        Task<BookingEntity> Update(BookingEntity entity);
    }
}
