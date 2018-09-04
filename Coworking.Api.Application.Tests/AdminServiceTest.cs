using Coworking.Api.Application.Contracts.Services;
using Coworking.Api.Application.Services;
using Coworking.Api.Application.Unit.Tests.MockRepository;
using Coworking.Api.Configuration;
using Coworking.Api.DataAccess.Contracts.Repositories;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace Coworking.Api.Application.Unit.Tests
{
    [TestClass]
    public class AdminServiceTest
    {


        private static IAdminService _adminService;


            [ClassInitialize()]
            public static void Setup(TestContext context)
            {

                Mock<IAdminRepository> _adminrepository = new AdminRepositoryMock()._adminRepository;
                Mock<IAppConfig> _appConfig = new AppConfigMock()._appConfig;

                _adminService = new AdminService(_adminrepository.Object, _appConfig.Object);

            }


        [TestMethod]
        public async Task llamando_a_getAdmin_dado_un_id_devuelve_un_admin_ok()
        {

            //preparacion

            //Ejecución 
            var result = await _adminService.GetAdmin(1);

            //Asercion
            result.Name.Should().NotBeNullOrEmpty();
            result.Id.Should().NotBe(2);

        }

        [TestMethod]
        public async Task dado_un_id_devuelve_un_admin_()
        {

            //preparacion

            //Ejecución 
            var result = await _adminService.GetAllAdmins();

            //Asercion
            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCountGreaterOrEqualTo(1);

        }

    }

}

