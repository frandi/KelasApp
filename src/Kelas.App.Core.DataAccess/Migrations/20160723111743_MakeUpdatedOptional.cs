using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kelas.App.Core.DataAccess.Migrations
{
    public partial class MakeUpdatedOptional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated",
                table: "Schools",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated",
                table: "ClassRooms",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated",
                table: "Schools",
                nullable: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated",
                table: "ClassRooms",
                nullable: false);
        }
    }
}
