using Coworking.Api.Application.Unit.Tests.Stubs;
using Coworking.Api.Configuration;
using Coworking.Api.DataAccess.Contracts.Entities;
using Coworking.Api.DataAccess.Contracts.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Coworking.Api.Application.Unit.Tests.MockRepository
{
    public class AppConfigMock
    {

        public Mock<IAppConfig> _appConfig { get; set; }


        public AppConfigMock()
        {
            _appConfig = new Mock<IAppConfig>();
        }


        private void Setup()
        {

        }


    }
}
