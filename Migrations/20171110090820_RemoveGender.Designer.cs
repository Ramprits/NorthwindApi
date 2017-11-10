using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WebApplicationNorthwind.Context;

namespace WebApplicationNorthwind.Migrations
{
    [DbContext(typeof(NorthWindDbContext))]
    [Migration("20171110090820_RemoveGender")]
    partial class RemoveGender
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplicationNorthwind.Entities.Employee", b =>
                {
                    b.Property<Guid>("EmployeeGuid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("Gender");

                    b.Property<string>("LastName");

                    b.Property<string>("Mobile");

                    b.HasKey("EmployeeGuid");

                    b.ToTable("Employee","mst");
                });
        }
    }
}
