﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WebApplicationNorthwind.Context;

namespace WebApplicationNorthwind.Migrations
{
    [DbContext(typeof(NorthWindDbContext))]
    [Migration("20171110061559_RemoveAddress")]
    partial class RemoveAddress
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

                    b.Property<Guid>("GenderGuid");

                    b.Property<string>("LastName");

                    b.Property<string>("Mobile");

                    b.HasKey("EmployeeGuid");

                    b.HasIndex("GenderGuid");

                    b.ToTable("Employee","mst");
                });

            modelBuilder.Entity("WebApplicationNorthwind.Entities.Gender", b =>
                {
                    b.Property<Guid>("GenderGuid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("GenderGuid");

                    b.ToTable("Gender","mst");
                });

            modelBuilder.Entity("WebApplicationNorthwind.Entities.Employee", b =>
                {
                    b.HasOne("WebApplicationNorthwind.Entities.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderGuid")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
