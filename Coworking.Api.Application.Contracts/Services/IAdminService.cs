using Coworking.Api.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Coworking.Api.Application.Contracts.Services
{
    public interface IAdminService
    {
        Task<IEnumerable<Admin>> GetAllAdmins();
        Task<Admin> GetAdmin(int id);
        Task<Admin> AddAdmin(Admin admin);
        Task DeleteAdmin(int id);
        Task<Admin> UpdateAdmin(Admin admin);

    }
}
