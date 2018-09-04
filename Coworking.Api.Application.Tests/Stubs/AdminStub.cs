using Coworking.Api.DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coworking.Api.Application.Unit.Tests.Stubs
{
    public static class AdminStub
    {

        public static AdminEntity admin_1 = new AdminEntity()
        {
            Email = "email@prueba,com",
            Id = 1,
            Name = "Prueba",
            Phone = "1111111"
        };

        public static AdminEntity admin_2 = new AdminEntity()
        {
            Email = "email2@prueba.com",
            Id = 2,
            Name = "Prueba2",
            Phone = "2222222222"
        };

        public static List<AdminEntity> adminList = new List<AdminEntity>(new AdminEntity[] { admin_1, admin_2 });


    }
}
