using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RailOps.Shared.Migrations
{
    public partial class InitialRoster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EngineModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngineModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RollingStockTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Class = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RollingStockTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Built = table.Column<string>(type: "TEXT", maxLength: 10, nullable: true),
                    Color = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    IsCaboose = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsFred = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsHazardous = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsLocationUnknown = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsOutOfService = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsPassenger = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsUtility = table.Column<bool>(type: "INTEGER", nullable: false),
                    LastDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Length = table.Column<int>(type: "INTEGER", nullable: false),
                    LoadGeneratedByStaging = table.Column<bool>(type: "INTEGER", nullable: false),
                    MoveCount = table.Column<int>(type: "INTEGER", nullable: false),
                    Owner = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    RoadId = table.Column<int>(type: "INTEGER", nullable: false),
                    RoadNumber = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    TypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Wait = table.Column<int>(type: "INTEGER", nullable: false),
                    Weight = table.Column<int>(type: "INTEGER", nullable: true),
                    WeightTons = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Roads_RoadId",
                        column: x => x.RoadId,
                        principalTable: "Roads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_RollingStockTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "RollingStockTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Engines",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Built = table.Column<string>(type: "TEXT", maxLength: 10, nullable: true),
                    Color = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    EngineModelId = table.Column<int>(type: "INTEGER", nullable: false),
                    EngineTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Horsepower = table.Column<int>(type: "INTEGER", nullable: false),
                    IsBUnit = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsLocationUnknown = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsOutOfService = table.Column<bool>(type: "INTEGER", nullable: false),
                    LastDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Length = table.Column<int>(type: "INTEGER", nullable: false),
                    MoveCount = table.Column<int>(type: "INTEGER", nullable: false),
                    Owner = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    RoadId = table.Column<int>(type: "INTEGER", nullable: false),
                    RoadNumber = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    TypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Weight = table.Column<int>(type: "INTEGER", nullable: true),
                    WeightTons = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Engines_EngineModels_EngineModelId",
                        column: x => x.EngineModelId,
                        principalTable: "EngineModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Engines_RollingStockTypes_EngineTypeId",
                        column: x => x.EngineTypeId,
                        principalTable: "RollingStockTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Engines_Roads_RoadId",
                        column: x => x.RoadId,
                        principalTable: "Roads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Engines_RollingStockTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "RollingStockTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_RoadId",
                table: "Cars",
                column: "RoadId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_TypeId",
                table: "Cars",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Engines_EngineModelId",
                table: "Engines",
                column: "EngineModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Engines_EngineTypeId",
                table: "Engines",
                column: "EngineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Engines_RoadId",
                table: "Engines",
                column: "RoadId");

            migrationBuilder.CreateIndex(
                name: "IX_Engines_TypeId",
                table: "Engines",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Engines");

            migrationBuilder.DropTable(
                name: "EngineModels");

            migrationBuilder.DropTable(
                name: "RollingStockTypes");

            migrationBuilder.DropTable(
                name: "Roads");
        }
    }
}
