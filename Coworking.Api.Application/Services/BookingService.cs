using Coworking.Api.Application.Contracts.Services;
using Coworking.Api.Business.Models;
using Coworking.Api.DataAccess.Contracts.Repositories;
using Coworking.Api.DataAccess.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coworking.Api.Application.Services
{
    public class BookingService : IBookingService
    {

        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }


        public async Task<Booking> AddBooking(Booking booking)
        {
            var addedEntity = await _bookingRepository.Add(BookingMapper.Map(booking));

            return BookingMapper.Map(addedEntity);
        }

        public async Task<IEnumerable<Booking>> GetAllBookings()
        {
            var bookings = await _bookingRepository.GetAll();

            return bookings.Select(BookingMapper.Map);
        }

        public async Task<Booking> GetBooking(int id)
        {
            var entidad = await _bookingRepository.Get(id);

            return BookingMapper.Map(entidad);
        }

        public async Task DeleteBooking(int id)
        {
            await _bookingRepository.DeleteAsync(id);
        }

        public async Task<Booking> UpdateBooking(Booking booking)
        {
            var updated = await _bookingRepository.Update(BookingMapper.Map(booking));

            return BookingMapper.Map(updated);
        }
    }
}
