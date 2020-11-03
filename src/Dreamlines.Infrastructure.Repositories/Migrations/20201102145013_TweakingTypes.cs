using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dreamlines.Infrastructure.Migrations
{
    public partial class TweakingTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Bookings",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BookingDate",
                table: "Bookings",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ShipId",
                table: "Bookings",
                column: "ShipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Ships_ShipId",
                table: "Bookings",
                column: "ShipId",
                principalTable: "Ships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Ships_ShipId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_ShipId",
                table: "Bookings");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Bookings",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "BookingDate",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
