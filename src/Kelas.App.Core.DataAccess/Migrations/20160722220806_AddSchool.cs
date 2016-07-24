using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kelas.App.Core.DataAccess.Migrations
{
    public partial class AddSchool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.Id);
                });

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "ClassRooms",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "SchoolId",
                table: "ClassRooms",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                table: "ClassRooms",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_ClassRooms_SchoolId",
                table: "ClassRooms",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Schools_Name",
                table: "Schools",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassRooms_Schools_SchoolId",
                table: "ClassRooms",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassRooms_Schools_SchoolId",
                table: "ClassRooms");

            migrationBuilder.DropIndex(
                name: "IX_ClassRooms_SchoolId",
                table: "ClassRooms");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "ClassRooms");

            migrationBuilder.DropColumn(
                name: "SchoolId",
                table: "ClassRooms");

            migrationBuilder.DropColumn(
                name: "Updated",
                table: "ClassRooms");

            migrationBuilder.DropTable(
                name: "Schools");
        }
    }
}
