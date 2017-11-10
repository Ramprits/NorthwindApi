using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationNorthwind.Migrations
{
    public partial class RemoveGender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Gender_GenderGuid",
                schema: "mst",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_GenderGuid",
                schema: "mst",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "GenderGuid",
                schema: "mst",
                table: "Employee");

            migrationBuilder.DropTable(
                name: "Gender",
                schema: "mst");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                schema: "mst",
                table: "Employee",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                schema: "mst",
                table: "Employee");

            migrationBuilder.CreateTable(
                name: "Gender",
                schema: "mst",
                columns: table => new
                {
                    GenderGuid = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.GenderGuid);
                });

            migrationBuilder.AddColumn<Guid>(
                name: "GenderGuid",
                schema: "mst",
                table: "Employee",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Employee_GenderGuid",
                schema: "mst",
                table: "Employee",
                column: "GenderGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Gender_GenderGuid",
                schema: "mst",
                table: "Employee",
                column: "GenderGuid",
                principalSchema: "mst",
                principalTable: "Gender",
                principalColumn: "GenderGuid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
