using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Picole.WebApi.Migrations
{
    public partial class AlterExtraTableAddUnit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_Extras_Oid",
                table: "Units");

            migrationBuilder.AddColumn<Guid>(
                name: "UnitOid",
                table: "Extras",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Extras_UnitOid",
                table: "Extras",
                column: "UnitOid");

            migrationBuilder.AddForeignKey(
                name: "FK_Extras_Units_UnitOid",
                table: "Extras",
                column: "UnitOid",
                principalTable: "Units",
                principalColumn: "Oid",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Extras_Units_UnitOid",
                table: "Extras");

            migrationBuilder.DropIndex(
                name: "IX_Extras_UnitOid",
                table: "Extras");

            migrationBuilder.DropColumn(
                name: "UnitOid",
                table: "Extras");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Extras_Oid",
                table: "Units",
                column: "Oid",
                principalTable: "Extras",
                principalColumn: "Oid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
