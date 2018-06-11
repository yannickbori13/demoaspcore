using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Picole.WebApi.Migrations
{
    public partial class AlterFermentaterChamberConfigurationAddReportDelay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReportDelay",
                table: "FermenterChamberConfigurations",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReportDelay",
                table: "FermenterChamberConfigurations");
        }
    }
}
