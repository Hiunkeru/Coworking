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
    public class RoomController : Controller
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        /// <summary>
        /// Get Room
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Produces("application/json", Type = typeof(RoomModel))]
        public async Task<IActionResult> Get(int id)
        {
            var admin = await _roomService.GetRoom(id);

            return Ok(admin);
        }

        /// <summary>
        /// Get all Room
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces("application/json", Type = typeof(List<RoomModel>))]
        public async Task<IActionResult> GetAll()
        {
            var admin = await _roomService.GetAllRooms();

            return Ok(admin);
        }

        /// <summary>
        /// Add a new Room
        /// </summary>
        /// <param name="admin"></param>
        /// <returns>Admin</returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(401)]
        [Produces("application/json",Type= typeof(RoomModel))]
        [HttpPost]
        public async Task<IActionResult> AddRoom([FromBody]RoomModel admin)
        {
            var name = await _roomService.AddRoom(RoomMapper.Map(admin));

            return Ok(name);
        }

        /// <summary>
        /// Borra un Room
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Produces("application/json", Type = typeof(bool))]
        public async Task<IActionResult> DeleteAdmin(int id)
        {
            await _roomService.DeleteRoom(id);

            return Ok();
        }

        /// <summary>
        /// Actualiza un Room
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        [HttpPut]
        [Produces("application/json", Type = typeof(RoomModel))]
        public async Task<IActionResult> UpdateAdmin([FromBody]RoomModel room)
        {
            var name = await _roomService.UpdateRoom(RoomMapper.Map(room));

            return Ok(name);
        }

    }
}