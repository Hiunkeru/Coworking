using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coworking.Api.Application.Contracts.Services;
using Coworking.Api.Configuration;
using Coworking.Api.Mappers;
using Coworking.Api.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Coworking.Api.Controllers
{
    //[Authorize]
    [Produces("application/json")]
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IAppConfig _config;
        private readonly IConfiguration _conf;

        public AdminController(IAdminService adminService, IAppConfig config ,IConfiguration conf)
        {
            _adminService = adminService;
            _config = config;
            _conf = conf;
        }

        /// <summary>
        /// Get admin
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Produces("application/json", Type = typeof(AdminModel))]
        public async Task<IActionResult> Get(int id)
        {

            var seconds = _config.ServiceUrl;

            var admin = await _adminService.GetAdmin(id);

            return Ok(admin);
        }

        // GET api/values
        [HttpGet]
        [Produces("application/json", Type = typeof(List<AdminModel>))]
        public async Task<IActionResult> GetAll()
        {
            var admin = await _adminService.GetAllAdmins();

            return Ok(admin);
        }

        /// <summary>
        /// Add a new Admin
        /// </summary>
        /// <param name="admin"></param>
        /// <returns>Admin</returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(401)]
        [Produces("application/json",Type= typeof(AdminModel))]
        [HttpPost]
        public async Task<IActionResult> AddAdmin([FromBody]AdminModel admin)
        {
            var name = await _adminService.AddAdmin(AdminMapper.Map(admin));

            return Ok(name);
        }

        /// <summary>
        /// Borra un admin
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Produces("application/json", Type = typeof(bool))]
        public async Task<IActionResult> DeleteAdmin(int id)
        {
            await _adminService.DeleteAdmin(id);

            return Ok();
        }

        /// <summary>
        /// Actualiza un Admin
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        [HttpPut]
        [Produces("application/json", Type = typeof(AdminModel))]
        public async Task<IActionResult> UpdateAdmin([FromBody]AdminModel admin)
        {
            var name = await _adminService.UpdateAdmin(AdminMapper.Map(admin));

            return Ok(name);
        }

    }
}