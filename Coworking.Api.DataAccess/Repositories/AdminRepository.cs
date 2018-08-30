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
    public class AdminRepository : IAdminRepository
    {
        //CRUD --> CREATE READ UPDATE DELETE

        private readonly ICoworkingDBContext _coworkingDBContext;

        public AdminRepository(ICoworkingDBContext coworkingDBContext)
        {
            _coworkingDBContext = coworkingDBContext;
        }

        public async Task<AdminEntity> Update(int  idEntity, AdminEntity updateEnt)
        {

            var entity = await Get(idEntity);

            entity.Name = updateEnt.Name;

            _coworkingDBContext.Admins.Update(entity);

            await _coworkingDBContext.SaveChangesAsync();

            return entity;
        }

        public async Task<AdminEntity> Update(AdminEntity entity)
        {

            var updateEntity = _coworkingDBContext.Admins.Update(entity);

            await _coworkingDBContext.SaveChangesAsync();

            return updateEntity.Entity;
        }

        public async Task<AdminEntity> Add(AdminEntity entity)
        {

            await _coworkingDBContext.Admins.AddAsync(entity);

            await _coworkingDBContext.SaveChangesAsync();

            return entity;
        }

        public async Task<AdminEntity> Get(int  idEntity)
        {

            var result = await _coworkingDBContext.Admins
                .FirstOrDefaultAsync(x=> x.Id == idEntity);

            return result;

        }

        public Task<bool> Exist(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AdminEntity>> GetAll()
        {
            return _coworkingDBContext.Admins.Select(x=> x);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _coworkingDBContext.Admins.SingleAsync(x => x.Id == id);

            _coworkingDBContext.Admins.Remove(entity);

            await _coworkingDBContext.SaveChangesAsync();

        }
    }
}
