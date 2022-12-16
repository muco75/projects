using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InAndOut.Migrations
{
    public partial class addGeboorteDatumColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Leeftijd",
                table: "Ttems");

            migrationBuilder.AddColumn<DateTime>(
                name: "GeboorteDatum",
                table: "Ttems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GeboorteDatum",
                table: "Ttems");

            migrationBuilder.AddColumn<int>(
                name: "Leeftijd",
                table: "Ttems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
