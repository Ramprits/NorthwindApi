using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationNorthwind.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "mst");

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

            migrationBuilder.CreateTable(
                name: "Employee",
                schema: "mst",
                columns: table => new
                {
                    EmployeeGuid = table.Column<Guid>(nullable: false),
                    AddressGuid = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    GenderGuid = table.Column<Guid>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeGuid);
                    table.ForeignKey(
                        name: "FK_Employee_Address_AddressGuid",
                        column: x => x.AddressGuid,
                        principalSchema: "mst",
                        principalTable: "Address",
                        principalColumn: "AddressGuid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_Gender_GenderGuid",
                        column: x => x.GenderGuid,
                        principalSchema: "mst",
                        principalTable: "Gender",
                        principalColumn: "GenderGuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_AddressGuid",
                schema: "mst",
                table: "Employee",
                column: "AddressGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_GenderGuid",
                schema: "mst",
                table: "Employee",
                column: "GenderGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee",
                schema: "mst");

            migrationBuilder.DropTable(
                name: "Address",
                schema: "mst");

            migrationBuilder.DropTable(
                name: "Gender",
                schema: "mst");
        }
    }
}
