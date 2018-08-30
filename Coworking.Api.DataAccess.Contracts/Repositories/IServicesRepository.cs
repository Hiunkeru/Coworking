using Coworking.Api.DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Coworking.Api.DataAccess.Contracts.Repositories
{
    public interface IServicesRepository : IRepository<ServiceEntity>
    {
        Task<ServiceEntity> Update(ServiceEntity entity);
    }
}
