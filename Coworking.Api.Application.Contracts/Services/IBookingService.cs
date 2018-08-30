using Coworking.Api.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Coworking.Api.Application.Contracts.Services
{
    public interface IBookingService
    {
        Task<Booking> AddBooking(Booking booking);
        Task<IEnumerable<Booking>> GetAllBookings();
        Task<Booking> GetBooking(int id);
        Task DeleteBooking(int id);
        Task<Booking> UpdateBooking(Booking booking);
    }
}
