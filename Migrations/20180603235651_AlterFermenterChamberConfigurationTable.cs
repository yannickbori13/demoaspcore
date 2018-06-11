using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Picole.WebApi.Migrations
{
    public partial class AlterFermenterChamberConfigurationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FermenterChamberConfigurations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "FermenterChamberConfigurations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "FermenterChamberConfigurations");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "FermenterChamberConfigurations");
        }
    }
}
