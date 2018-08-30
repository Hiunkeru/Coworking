using Coworking.Api.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Coworking.Api.Application.Contracts.Services
{
    public interface IServicesService
    {
        Task<Service> AddService(Service service);
        Task<IEnumerable<Service>> GetAllServices();
        Task<Service> GetService(int id);
        Task DeleteService(int id);
        Task<Service> UpdateService(Service service);

    }
}
