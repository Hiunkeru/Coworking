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
    public class ServicesService : IServicesService
    {

        private readonly IServicesRepository _servicesRepository;

        public ServicesService(IServicesRepository servicesRepository)
        {
            _servicesRepository = servicesRepository;
        }


        public async Task<Service> AddService(Service service)
        {
            var addedEntity = await _servicesRepository.Add(ServiceMapper.Map(service));

            return ServiceMapper.Map(addedEntity);
        }

        public async Task<IEnumerable<Service>> GetAllServices()
        {
            var admins = await _servicesRepository.GetAll();

            return admins.Select(ServiceMapper.Map);
        }

        public async Task<Service> GetService(int id)
        {
            var entidad = await _servicesRepository.Get(id);

            return ServiceMapper.Map(entidad);
        }

        public async Task DeleteService(int id)
        {
            await _servicesRepository.DeleteAsync(id);
        }

        public async Task<Service> UpdateService(Service service)
        {
            var updated = await _servicesRepository.Update(ServiceMapper.Map(service));

            return ServiceMapper.Map(updated);
        }
    }
}
