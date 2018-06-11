using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Picole.WebApi.Migrations
{
    public partial class AddFermenterChamberConfigurationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FermenterChamberConfigurations",
                columns: table => new
                {
                    Oid = table.Column<Guid>(nullable: false),
                    TemperatureMaximum = table.Column<int>(nullable: false),
                    TemperatureMinimum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FermenterChamberConfigurations", x => x.Oid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FermenterChamberConfigurations");
        }
    }
}
