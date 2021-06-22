using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MASP.Migrations
{
    public partial class ss3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Airport_AirportIdAirport",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Flights_FlightIdFlight",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Order_OrderIdOrder",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_AirportIdAirport",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_FlightIdFlight",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_OrderIdOrder",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "AirportIdAirport",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "FlightIdFlight",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "OrderIdOrder",
                table: "Ticket");

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "IdFlight",
                keyValue: 1,
                column: "LandingDate",
                value: new DateTime(2021, 6, 13, 0, 28, 4, 999, DateTimeKind.Local).AddTicks(738));

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "IdFlight",
                keyValue: 2,
                column: "LandingDate",
                value: new DateTime(2021, 6, 13, 0, 28, 4, 999, DateTimeKind.Local).AddTicks(2363));

            migrationBuilder.UpdateData(
                table: "Plane",
                keyColumn: "IdPlane",
                keyValue: 1,
                column: "LastRepair",
                value: new DateTime(2021, 6, 13, 0, 28, 5, 23, DateTimeKind.Local).AddTicks(6493));

            migrationBuilder.UpdateData(
                table: "Plane",
                keyColumn: "IdPlane",
                keyValue: 2,
                column: "LastRepair",
                value: new DateTime(2021, 6, 13, 0, 28, 5, 23, DateTimeKind.Local).AddTicks(7339));

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_IdAirport",
                table: "Ticket",
                column: "IdAirport");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_IdFlight",
                table: "Ticket",
                column: "IdFlight");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_IdOrder",
                table: "Ticket",
                column: "IdOrder");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Airport_IdAirport",
                table: "Ticket",
                column: "IdAirport",
                principalTable: "Airport",
                principalColumn: "IdAirport");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Flights_IdFlight",
                table: "Ticket",
                column: "IdFlight",
                principalTable: "Flights",
                principalColumn: "IdFlight");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Order_IdOrder",
                table: "Ticket",
                column: "IdOrder",
                principalTable: "Order",
                principalColumn: "IdOrder");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Airport_IdAirport",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Flights_IdFlight",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Order_IdOrder",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_IdAirport",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_IdFlight",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_IdOrder",
                table: "Ticket");

            migrationBuilder.AddColumn<int>(
                name: "AirportIdAirport",
                table: "Ticket",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FlightIdFlight",
                table: "Ticket",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderIdOrder",
                table: "Ticket",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "IdFlight",
                keyValue: 1,
                column: "LandingDate",
                value: new DateTime(2021, 6, 13, 0, 3, 47, 631, DateTimeKind.Local).AddTicks(6770));

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "IdFlight",
                keyValue: 2,
                column: "LandingDate",
                value: new DateTime(2021, 6, 13, 0, 3, 47, 631, DateTimeKind.Local).AddTicks(8495));

            migrationBuilder.UpdateData(
                table: "Plane",
                keyColumn: "IdPlane",
                keyValue: 1,
                column: "LastRepair",
                value: new DateTime(2021, 6, 13, 0, 3, 47, 656, DateTimeKind.Local).AddTicks(3400));

            migrationBuilder.UpdateData(
                table: "Plane",
                keyColumn: "IdPlane",
                keyValue: 2,
                column: "LastRepair",
                value: new DateTime(2021, 6, 13, 0, 3, 47, 656, DateTimeKind.Local).AddTicks(4860));

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_AirportIdAirport",
                table: "Ticket",
                column: "AirportIdAirport");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_FlightIdFlight",
                table: "Ticket",
                column: "FlightIdFlight");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_OrderIdOrder",
                table: "Ticket",
                column: "OrderIdOrder");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Airport_AirportIdAirport",
                table: "Ticket",
                column: "AirportIdAirport",
                principalTable: "Airport",
                principalColumn: "IdAirport",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Flights_FlightIdFlight",
                table: "Ticket",
                column: "FlightIdFlight",
                principalTable: "Flights",
                principalColumn: "IdFlight",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Order_OrderIdOrder",
                table: "Ticket",
                column: "OrderIdOrder",
                principalTable: "Order",
                principalColumn: "IdOrder",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
