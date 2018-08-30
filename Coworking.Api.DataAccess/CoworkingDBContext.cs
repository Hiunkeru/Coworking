using Coworking.Api.DataAccess.Contracts;
using Coworking.Api.DataAccess.Contracts.Entities;
using Coworking.Api.DataAccess.EntityConfig;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coworking.Api.DataAccess
{
    public class CoworkingDBContext : DbContext, ICoworkingDBContext
    {

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<AdminEntity> Admins { get; set; }
        public DbSet<BookingEntity> Bookings { get; set; }
        public DbSet<OfficeEntity> Offices { get; set; }
        public DbSet<Offices2RoomsEntity> Offices2Rooms { get; set; }
        public DbSet<Room2ServicesEntity> Room2Services { get; set; }
        public DbSet<RoomEntity> Rooms { get; set; }
        public DbSet<ServiceEntity> Services { get; set; }


        public CoworkingDBContext(DbContextOptions options) : base(options) { }

        public CoworkingDBContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AdminEntityConfig.SetEntityBuilder(modelBuilder.Entity<AdminEntity>());
            BookingEntityConfig.SetEntityBuilder(modelBuilder.Entity<BookingEntity>());
            Office2RoomEntityConfig.SetEntityBuilder(modelBuilder.Entity<Offices2RoomsEntity>());
            OfficeEntityConfig.SetEntityBuilder(modelBuilder.Entity<OfficeEntity>());
            Room2ServiceEntityConfig.SetEntityBuilder(modelBuilder.Entity<Room2ServicesEntity>());
            AdminEntityConfig.SetEntityBuilder(modelBuilder.Entity<AdminEntity>());
            RoomEntityConfig.SetEntityBuilder(modelBuilder.Entity<RoomEntity>());
            ServiceEntityConfig.SetEntityBuilder(modelBuilder.Entity<ServiceEntity>());
            UserEntityConfig.SetEntityBuilder(modelBuilder.Entity<UserEntity>());

            base.OnModelCreating(modelBuilder);

        }
    }
}
