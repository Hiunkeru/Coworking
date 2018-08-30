using Coworking.Api.Application.Contracts.Services;
using Coworking.Api.Business.Models;
using Coworking.Api.Configuration;
using Coworking.Api.DataAccess.Contracts.Repositories;
using Coworking.Api.DataAccess.Mappers;
using Microsoft.Extensions.Caching.Memory;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coworking.Api.Application.Services
{
    public class AdminService : IAdminService
    {

        private readonly IAdminRepository _adminRepository;
        private readonly IAppConfig _appConfig;
        private IMemoryCache _memoryCache;

        public AdminService(IAdminRepository adminRepository, IAppConfig appConfig, IMemoryCache memoryCache)
        {
            _adminRepository = adminRepository;
            _appConfig = appConfig;
            _memoryCache = memoryCache;

            MemoryCacheEntryOptions cacheConfig = new MemoryCacheEntryOptions();
            cacheConfig.Priority = CacheItemPriority.Normal;
            cacheConfig.AbsoluteExpiration = DateTime.Now.AddMinutes(appConfig.CacheExpireInMinutes);

        }


        public async Task<Admin> AddAdmin(Admin admin)
        {

            var maxTrys = _appConfig.MaxTrys;
            var timeToWait = TimeSpan.FromSeconds(_appConfig.SecondsToWait);

            var retryPolity = Policy.Handle<Exception>().WaitAndRetryAsync(maxTrys,i=> timeToWait);

            return await retryPolity.ExecuteAsync(async () =>
            {

                var addedEntity = await _adminRepository.Add(AdminMapper.Map(admin));
                return AdminMapper.Map(addedEntity);

            });

        }

        public async Task<IEnumerable<Admin>> GetAllAdmins()
        {

            //return await _memoryCache.GetOrCreateAsync("admins", async cacheEntry =>
            //{

                var admins = await _adminRepository.GetAll();

                return admins.Select(AdminMapper.Map);

            //});

            
        }

        public async Task<Admin> GetAdmin(int id)
        {
            var entidad = await _adminRepository.Get(id);

            return AdminMapper.Map(entidad);
        }

        public async Task DeleteAdmin(int id)
        {
            await _adminRepository.DeleteAsync(id);
        }

        public async Task<Admin> UpdateAdmin(Admin admin)
        {
            var updated = await _adminRepository.Update(AdminMapper.Map(admin));

            return AdminMapper.Map(updated);
        }
    }
}
