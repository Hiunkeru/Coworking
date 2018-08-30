using Coworking.Api.DataAccess.Contracts;
using Coworking.Api.DataAccess.Contracts.Entities;
using Coworking.Api.DataAccess.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coworking.Api.DataAccess.Repositories
{
    public class ServicesRepository : IServicesRepository
    {
        //CRUD --> CREATE READ UPDATE DELETE

        private readonly ICoworkingDBContext _coworkingDBContext;

        public ServicesRepository(ICoworkingDBContext coworkingDBContext)
        {
            _coworkingDBContext = coworkingDBContext;
        }

        public async Task<ServiceEntity> Update(int  idEntity, ServiceEntity updateEnt)
        {

            var entity = await Get(idEntity);

            entity.Name = updateEnt.Name;

            _coworkingDBContext.Services.Update(entity);

            await _coworkingDBContext.SaveChangesAsync();

            return entity;
        }

        public async Task<ServiceEntity> Update(ServiceEntity entity)
        {

            var updateEntity = _coworkingDBContext.Services.Update(entity);

            await _coworkingDBContext.SaveChangesAsync();

            return updateEntity.Entity;
        }

        public async Task<ServiceEntity> Add(ServiceEntity entity)
        {

            await _coworkingDBContext.Services.AddAsync(entity);

            await _coworkingDBContext.SaveChangesAsync();

            return entity;
        }

        public async Task<ServiceEntity> Get(int  idEntity)
        {

            var result = await _coworkingDBContext.Services.FirstOrDefaultAsync(x=> x.Id == idEntity);

            return result;

        }

        public Task<bool> Exist(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ServiceEntity>> GetAll()
        {
            return _coworkingDBContext.Services.Select(x => x);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _coworkingDBContext.Services.SingleAsync(x => x.Id == id);

            _coworkingDBContext.Services.Remove(entity);

            await _coworkingDBContext.SaveChangesAsync();

        }
    }
}
