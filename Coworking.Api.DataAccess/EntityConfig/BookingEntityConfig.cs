using Coworking.Api.DataAccess.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coworking.Api.DataAccess.EntityConfig
{
    public class BookingEntityConfig
    {

        public static void SetEntityBuilder(EntityTypeBuilder<BookingEntity> entityBuilder)
        {

            entityBuilder.ToTable("Bookings");

            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Id).IsRequired();

            entityBuilder.HasOne(x => x.Office).WithOne(x => x.Booking);
            entityBuilder.HasOne(x => x.User).WithOne(x => x.Booking);
        }


    }
}
