using Coworking.Api.Application.ApiCaller;
using Coworking.Api.Application.Contracts.ApiCaller;
using Coworking.Api.Application.Contracts.Services;
using Coworking.Api.Application.Services;
using Coworking.Api.Configuration;
using Coworking.Api.DataAccess.Contracts.Repositories;
using Coworking.Api.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coworking.Api.CrossCutting.Register
{
    public static class IoCRegister
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {

            AddRegisterServices(services);
            AddRegisterRepositories(services);
            AddRegisterOthers(services);

            return services;

        }

        private static IServiceCollection AddRegisterServices(IServiceCollection services)
        {

            services.AddTransient<IAdminService, AdminService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoomService, RoomService>();
            services.AddTransient<IOfficeService, OfficesService>();
            services.AddTransient<IBookingService, BookingService>();
            services.AddTransient<IServicesService, ServicesService>();

            return services;
        }

        private static IServiceCollection AddRegisterRepositories(IServiceCollection services)
        {

            services.AddTransient<IAdminRepository, AdminRepository>();
            services.AddTransient<IBookingRepository, BookingRepository>();
            services.AddTransient<IOfficeRepository, OfficeRepository>();
            services.AddTransient<IRoomRepository, RoomRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IServicesRepository, ServicesRepository>();

            return services;
        }

        private static IServiceCollection AddRegisterOthers(IServiceCollection services)
        {

            services.AddTransient<IAppConfig, AppConfig>();
            services.AddTransient<IApiCaller, ApiCaller>();


            return services;
        }
        



    }
}
