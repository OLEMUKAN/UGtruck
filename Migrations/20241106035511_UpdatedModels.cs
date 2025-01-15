using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TruckLoadingApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "CurrentLoadWeight",
                table: "Trucks",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MaintenanceDueDate",
                table: "Trucks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BookingId1",
                table: "Load",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Load_BookingId1",
                table: "Load",
                column: "BookingId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Load_Bookings_BookingId1",
                table: "Load",
                column: "BookingId1",
                principalTable: "Bookings",
                principalColumn: "BookingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Load_Bookings_BookingId1",
                table: "Load");

            migrationBuilder.DropIndex(
                name: "IX_Load_BookingId1",
                table: "Load");

            migrationBuilder.DropColumn(
                name: "CurrentLoadWeight",
                table: "Trucks");

            migrationBuilder.DropColumn(
                name: "MaintenanceDueDate",
                table: "Trucks");

            migrationBuilder.DropColumn(
                name: "BookingId1",
                table: "Load");
        }
    }
}
