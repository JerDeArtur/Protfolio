using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MASP.Migrations
{
    public partial class ss4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "IdFlight",
                keyValue: 1,
                column: "LandingDate",
                value: new DateTime(2021, 6, 13, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "IdFlight",
                keyValue: 2,
                column: "LandingDate",
                value: new DateTime(2021, 6, 13, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Plane",
                keyColumn: "IdPlane",
                keyValue: 1,
                column: "LastRepair",
                value: new DateTime(2021, 6, 13, 2, 30, 17, 173, DateTimeKind.Local).AddTicks(4725));

            migrationBuilder.UpdateData(
                table: "Plane",
                keyColumn: "IdPlane",
                keyValue: 2,
                column: "LastRepair",
                value: new DateTime(2021, 6, 13, 2, 30, 17, 173, DateTimeKind.Local).AddTicks(5689));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
