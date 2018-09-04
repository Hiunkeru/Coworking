using Coworking.Api.Application.Unit.Tests.Stubs;
using Coworking.Api.DataAccess.Contracts.Entities;
using Coworking.Api.DataAccess.Contracts.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Coworking.Api.Application.Unit.Tests.MockRepository
{
    public class AdminRepositoryMock
    {

        public Mock<IAdminRepository> _adminRepository { get; set; }


        public AdminRepositoryMock()
        {
            _adminRepository = new Mock<IAdminRepository>();
            Setup();
        }


        private void Setup()
        {
            _adminRepository.Setup((x) => x.Add(It.IsAny<AdminEntity>())).ReturnsAsync(AdminStub.admin_1);
            _adminRepository.Setup((x) => x.DeleteAsync(It.Is<int>(p => p.Equals(3)))).Returns(Task.Delay(5));
            _adminRepository.Setup((x) => x.DeleteAsync(It.Is<int>(p => !p.Equals(3)))).Returns(Task.Delay(10));
            _adminRepository.Setup((x) => x.Exist(It.IsAny<int>())).ReturnsAsync(true);
            _adminRepository.Setup((x) => x.Get(It.IsAny<int>())).ReturnsAsync(AdminStub.admin_1);
            _adminRepository.Setup((x) => x.GetAll()).ReturnsAsync(AdminStub.adminList);
            _adminRepository.Setup((x) => x.Update(It.IsAny<AdminEntity>())).ReturnsAsync(AdminStub.admin_1);
        }


    }
}
