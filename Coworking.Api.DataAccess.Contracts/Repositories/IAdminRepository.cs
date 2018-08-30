using Coworking.Api.DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Coworking.Api.DataAccess.Contracts.Repositories
{
    public interface IAdminRepository : IRepository<AdminEntity>
    {
        Task<AdminEntity> Update(AdminEntity entity);
    }
}
