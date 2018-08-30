using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Coworking.Api.DataAccess.Migrations
{
    public partial class changeAdminEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Offices_OfficeId",
                table: "Admins");

            migrationBuilder.DropIndex(
                name: "IX_Admins_OfficeId",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "OfficeId",
                table: "Admins");

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Offices",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offices_AdminId",
                table: "Offices",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offices_Admins_AdminId",
                table: "Offices",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offices_Admins_AdminId",
                table: "Offices");

            migrationBuilder.DropIndex(
                name: "IX_Offices_AdminId",
                table: "Offices");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Offices");

            migrationBuilder.AddColumn<int>(
                name: "OfficeId",
                table: "Admins",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Admins_OfficeId",
                table: "Admins",
                column: "OfficeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Offices_OfficeId",
                table: "Admins",
                column: "OfficeId",
                principalTable: "Offices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
