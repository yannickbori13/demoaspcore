﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Picole.WebApi.Models;
using System;

namespace Picole.WebApi.Migrations
{
    [DbContext(typeof(PicoleDbContext))]
    partial class PicoleDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026");

            modelBuilder.Entity("Picole.WebApi.Models.Extra", b =>
                {
                    b.Property<Guid>("Oid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<Guid?>("UnitOid");

                    b.HasKey("Oid");

                    b.HasIndex("UnitOid");

                    b.ToTable("Extras");
                });

            modelBuilder.Entity("Picole.WebApi.Models.Fermentable", b =>
                {
                    b.Property<Guid>("Oid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Link");

                    b.Property<string>("Name");

                    b.Property<string>("Vendor");

                    b.HasKey("Oid");

                    b.ToTable("Fermentables");
                });

            modelBuilder.Entity("Picole.WebApi.Models.FermenterChamberConfiguration", b =>
                {
                    b.Property<Guid>("Oid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("ReportDelay");

                    b.Property<int>("TemperatureMaximum");

                    b.Property<int>("TemperatureMinimum");

                    b.HasKey("Oid");

                    b.ToTable("FermenterChamberConfigurations");
                });

            modelBuilder.Entity("Picole.WebApi.Models.Hops", b =>
                {
                    b.Property<Guid>("Oid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Link");

                    b.Property<string>("Name");

                    b.Property<string>("Vendor");

                    b.HasKey("Oid");

                    b.ToTable("Hops");
                });

            modelBuilder.Entity("Picole.WebApi.Models.SensorLog", b =>
                {
                    b.Property<Guid>("Oid")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("FromIp");

                    b.Property<string>("Remark");

                    b.Property<string>("Type");

                    b.Property<float>("Value");

                    b.HasKey("Oid");

                    b.ToTable("SensorLogs");
                });

            modelBuilder.Entity("Picole.WebApi.Models.Unit", b =>
                {
                    b.Property<Guid>("Oid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Oid");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("Picole.WebApi.Models.UseType", b =>
                {
                    b.Property<Guid>("Oid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Oid");

                    b.ToTable("UseTypes");
                });

            modelBuilder.Entity("Picole.WebApi.Models.Yeast", b =>
                {
                    b.Property<Guid>("Oid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Link");

                    b.Property<string>("Name");

                    b.Property<string>("ProductNumber");

                    b.Property<string>("Vendor");

                    b.HasKey("Oid");

                    b.ToTable("Yeasts");
                });

            modelBuilder.Entity("Picole.WebApi.Models.Extra", b =>
                {
                    b.HasOne("Picole.WebApi.Models.Unit", "Unit")
                        .WithMany("Extras")
                        .HasForeignKey("UnitOid");
                });
#pragma warning restore 612, 618
        }
    }
}
