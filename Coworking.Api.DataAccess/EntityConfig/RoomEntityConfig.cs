using Coworking.Api.DataAccess.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coworking.Api.DataAccess.EntityConfig
{
    public class RoomEntityConfig
    {

        public static void SetEntityBuilder(EntityTypeBuilder<RoomEntity> entityBuilder)
        {

            entityBuilder.ToTable("Rooms");

            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Id).IsRequired();

            //entityBuilder.HasOne(x => x.).WithOne(x => x.Admin);

        }


    }
}
