using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MASP.Migrations
{
    public partial class ssd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "Order",
                type: "float",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "IdFlight",
                keyValue: 1,
                columns: new[] { "LandingDate", "TakeOffDate" },
                values: new object[] { new DateTime(2021, 6, 14, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 6, 14, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "IdFlight",
                keyValue: 2,
                columns: new[] { "LandingDate", "TakeOffDate" },
                values: new object[] { new DateTime(2021, 6, 14, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 6, 14, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Plane",
                keyColumn: "IdPlane",
                keyValue: 1,
                column: "LastRepair",
                value: new DateTime(2021, 6, 14, 2, 32, 46, 234, DateTimeKind.Local).AddTicks(7351));

            migrationBuilder.UpdateData(
                table: "Plane",
                keyColumn: "IdPlane",
                keyValue: 2,
                column: "LastRepair",
                value: new DateTime(2021, 6, 14, 2, 32, 46, 234, DateTimeKind.Local).AddTicks(8667));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Order");

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "IdFlight",
                keyValue: 1,
                columns: new[] { "LandingDate", "TakeOffDate" },
                values: new object[] { new DateTime(2021, 6, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 6, 13, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "IdFlight",
                keyValue: 2,
                columns: new[] { "LandingDate", "TakeOffDate" },
                values: new object[] { new DateTime(2021, 6, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 6, 13, 0, 0, 0, 0, DateTimeKind.Local) });

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
    }
}
