using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coworking.Api.Application.Contracts.Services;
using Coworking.Api.Mappers;
using Coworking.Api.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Coworking.Api.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        /// <summary>
        /// Get Booking
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Produces("application/json", Type = typeof(AdminModel))]
        public async Task<IActionResult> Get(int id)
        {
            var admin = await _bookingService.GetBooking(id);

            return Ok(admin);
        }

        /// <summary>
        /// Get all Booking
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces("application/json", Type = typeof(List<BookingModel>))]
        public async Task<IActionResult> GetAll()
        {
            var admin = await _bookingService.GetAllBookings();

            return Ok(admin);
        }

        /// <summary>
        /// Add a new Booking
        /// </summary>
        /// <param name="admin"></param>
        /// <returns>Admin</returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(401)]
        [Produces("application/json",Type= typeof(BookingModel))]
        [HttpPost]
        public async Task<IActionResult> AddBooking([FromBody]BookingModel booking)
        {
            var bookingDone = await _bookingService.AddBooking(BookingMapper.Map(booking));

            return Ok(bookingDone);
        }

        /// <summary>
        /// Borra un Booking
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Produces("application/json", Type = typeof(bool))]
        public async Task<IActionResult> DeleteAdmin(int id)
        {
            await _bookingService.DeleteBooking(id);

            return Ok();
        }

        /// <summary>
        /// Actualiza un Booking
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        [HttpPut]
        [Produces("application/json", Type = typeof(BookingModel))]
        public async Task<IActionResult> UpdateAdmin([FromBody]BookingModel booking)
        {
            var updatedBooking = await _bookingService.UpdateBooking(BookingMapper.Map(booking));

            return Ok(updatedBooking);
        }

    }
}