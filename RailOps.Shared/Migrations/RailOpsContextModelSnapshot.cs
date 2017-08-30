﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using RailOps.Shared.Data;
using RailOps.Shared.Domain.Roster;
using System;

namespace RailOps.Shared.Migrations
{
    [DbContext(typeof(RailOpsContext))]
    partial class RailOpsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RailOps.Shared.Domain.Roster.Car", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Built")
                        .HasMaxLength(10);

                    b.Property<string>("Color")
                        .HasMaxLength(50);

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<bool>("IsCaboose");

                    b.Property<bool>("IsFred");

                    b.Property<bool>("IsHazardous");

                    b.Property<bool>("IsLocationUnknown");

                    b.Property<bool>("IsOutOfService");

                    b.Property<bool>("IsPassenger");

                    b.Property<bool>("IsUtility");

                    b.Property<DateTime>("LastDate");

                    b.Property<int>("Length");

                    b.Property<bool>("LoadGeneratedByStaging");

                    b.Property<int>("MoveCount");

                    b.Property<string>("Owner")
                        .HasMaxLength(50);

                    b.Property<int>("RoadId");

                    b.Property<string>("RoadNumber")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<int>("TypeId");

                    b.Property<int>("Wait");

                    b.Property<int?>("Weight");

                    b.Property<int?>("WeightTons");

                    b.HasKey("Id");

                    b.HasIndex("RoadId");

                    b.HasIndex("TypeId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("RailOps.Shared.Domain.Roster.Engine", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Built")
                        .HasMaxLength(10);

                    b.Property<string>("Color")
                        .HasMaxLength(50);

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<int>("EngineModelId");

                    b.Property<int>("EngineTypeId");

                    b.Property<int>("Horsepower");

                    b.Property<bool>("IsBUnit");

                    b.Property<bool>("IsLocationUnknown");

                    b.Property<bool>("IsOutOfService");

                    b.Property<DateTime>("LastDate");

                    b.Property<int>("Length");

                    b.Property<int>("MoveCount");

                    b.Property<string>("Owner")
                        .HasMaxLength(50);

                    b.Property<int>("RoadId");

                    b.Property<string>("RoadNumber")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<int>("TypeId");

                    b.Property<int?>("Weight");

                    b.Property<int?>("WeightTons");

                    b.HasKey("Id");

                    b.HasIndex("EngineModelId");

                    b.HasIndex("EngineTypeId");

                    b.HasIndex("RoadId");

                    b.HasIndex("TypeId");

                    b.ToTable("Engines");
                });

            modelBuilder.Entity("RailOps.Shared.Domain.Roster.EngineModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("EngineModels");
                });

            modelBuilder.Entity("RailOps.Shared.Domain.Roster.Road", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Roads");
                });

            modelBuilder.Entity("RailOps.Shared.Domain.Roster.RollingStockType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Class");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("RollingStockTypes");
                });

            modelBuilder.Entity("RailOps.Shared.Domain.Roster.Car", b =>
                {
                    b.HasOne("RailOps.Shared.Domain.Roster.Road", "Road")
                        .WithMany()
                        .HasForeignKey("RoadId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RailOps.Shared.Domain.Roster.RollingStockType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RailOps.Shared.Domain.Roster.Engine", b =>
                {
                    b.HasOne("RailOps.Shared.Domain.Roster.EngineModel", "EngineModel")
                        .WithMany()
                        .HasForeignKey("EngineModelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RailOps.Shared.Domain.Roster.RollingStockType", "EngineType")
                        .WithMany()
                        .HasForeignKey("EngineTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RailOps.Shared.Domain.Roster.Road", "Road")
                        .WithMany()
                        .HasForeignKey("RoadId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RailOps.Shared.Domain.Roster.RollingStockType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
