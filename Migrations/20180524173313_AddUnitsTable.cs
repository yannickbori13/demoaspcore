using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Picole.WebApi.Migrations
{
    public partial class AddUnitsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Unit_Extras_Oid",
                table: "Unit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Unit",
                table: "Unit");

            migrationBuilder.RenameTable(
                name: "Unit",
                newName: "Units");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Units",
                table: "Units",
                column: "Oid");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Extras_Oid",
                table: "Units",
                column: "Oid",
                principalTable: "Extras",
                principalColumn: "Oid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_Extras_Oid",
                table: "Units");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Units",
                table: "Units");

            migrationBuilder.RenameTable(
                name: "Units",
                newName: "Unit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Unit",
                table: "Unit",
                column: "Oid");

            migrationBuilder.AddForeignKey(
                name: "FK_Unit_Extras_Oid",
                table: "Unit",
                column: "Oid",
                principalTable: "Extras",
                principalColumn: "Oid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
