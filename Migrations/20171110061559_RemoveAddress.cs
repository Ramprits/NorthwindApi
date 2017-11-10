using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationNorthwind.Migrations
{
    public partial class RemoveAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Address_AddressGuid",
                schema: "mst",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_AddressGuid",
                schema: "mst",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "AddressGuid",
                schema: "mst",
                table: "Employee");

            migrationBuilder.DropTable(
                name: "Address",
                schema: "mst");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "mst",
                table: "Employee",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                schema: "mst",
                table: "Employee");

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "mst",
                columns: table => new
                {
                    AddressGuid = table.Column<Guid>(nullable: false),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressGuid);
                });

            migrationBuilder.AddColumn<Guid>(
                name: "AddressGuid",
                schema: "mst",
                table: "Employee",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Employee_AddressGuid",
                schema: "mst",
                table: "Employee",
                column: "AddressGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Address_AddressGuid",
                schema: "mst",
                table: "Employee",
                column: "AddressGuid",
                principalSchema: "mst",
                principalTable: "Address",
                principalColumn: "AddressGuid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
