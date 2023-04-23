using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiletAPI.Infrastructure.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CityId",
                table: "Expeditions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Expeditions_CityId",
                table: "Expeditions",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expeditions_Cities_CityId",
                table: "Expeditions",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expeditions_Cities_CityId",
                table: "Expeditions");

            migrationBuilder.DropIndex(
                name: "IX_Expeditions_CityId",
                table: "Expeditions");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Expeditions");
        }
    }
}
