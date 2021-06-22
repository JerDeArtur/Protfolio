using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MASP.Migrations
{
    public partial class ss2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactData",
                columns: table => new
                {
                    IdCD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PostCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AppartmentNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CD_PK", x => x.IdCD);
                });

            migrationBuilder.CreateTable(
                name: "Airport",
                columns: table => new
                {
                    IdAirport = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NumberOfLines = table.Column<int>(type: "int", nullable: false),
                    IdCD = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Airport_PK", x => x.IdAirport);
                    table.ForeignKey(
                        name: "FK_Airport_ContactData_IdCD",
                        column: x => x.IdCD,
                        principalTable: "ContactData",
                        principalColumn: "IdCD",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    IdPerson = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdCD = table.Column<int>(type: "int", nullable: false),
                    PESEL = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Salary = table.Column<double>(type: "float", nullable: true),
                    IdEmp = table.Column<int>(type: "int", nullable: true),
                    Login = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Logined = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IdType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Person_PK", x => x.IdPerson);
                    table.ForeignKey(
                        name: "FK_Person_ContactData_IdCD",
                        column: x => x.IdCD,
                        principalTable: "ContactData",
                        principalColumn: "IdCD",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plane",
                columns: table => new
                {
                    IdPlane = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAirport = table.Column<int>(type: "int", nullable: false),
                    LastRepair = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SeatsCount = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValue: "Ready")
                },
                constraints: table =>
                {
                    table.PrimaryKey("Plane_PK", x => x.IdPlane);
                    table.ForeignKey(
                        name: "FK_Plane_Airport_IdAirport",
                        column: x => x.IdAirport,
                        principalTable: "Airport",
                        principalColumn: "IdAirport",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employment",
                columns: table => new
                {
                    IdEmployment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPerson = table.Column<int>(type: "int", nullable: true),
                    IdAirport = table.Column<int>(type: "int", nullable: true),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Retire = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Characteristics = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Employment_PK", x => x.IdEmployment);
                    table.ForeignKey(
                        name: "FK_Employment_Airport_IdAirport",
                        column: x => x.IdAirport,
                        principalTable: "Airport",
                        principalColumn: "IdAirport");
                    table.ForeignKey(
                        name: "FK_Employment_Person_IdPerson",
                        column: x => x.IdPerson,
                        principalTable: "Person",
                        principalColumn: "IdPerson");
                });

            migrationBuilder.CreateTable(
                name: "Mechanik",
                columns: table => new
                {
                    IdMechanik = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonthlyRepairs = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    IdPerson = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Mechanik_PK", x => x.IdMechanik);
                    table.ForeignKey(
                        name: "FK_Mechanik_Person_IdPerson",
                        column: x => x.IdPerson,
                        principalTable: "Person",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    IdOrder = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    Payed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IdPerson = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Order_PK", x => x.IdOrder);
                    table.ForeignKey(
                        name: "FK_Order_Person_IdPerson",
                        column: x => x.IdPerson,
                        principalTable: "Person",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pilot",
                columns: table => new
                {
                    IdPilot = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPerson = table.Column<int>(type: "int", nullable: false),
                    TotalPractice = table.Column<int>(type: "int", nullable: false),
                    MonthlyFlights = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pilot_PK", x => x.IdPilot);
                    table.ForeignKey(
                        name: "FK_Pilot_Person_IdPerson",
                        column: x => x.IdPerson,
                        principalTable: "Person",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    IdStaff = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeeklyWorkTime = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    IdPerson = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Staff_PK", x => x.IdStaff);
                    table.ForeignKey(
                        name: "FK_Staff_Person_IdPerson",
                        column: x => x.IdPerson,
                        principalTable: "Person",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Education",
                columns: table => new
                {
                    IdEducation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    University = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Grade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IdMechanik = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Education_PK", x => x.IdEducation);
                    table.ForeignKey(
                        name: "FK_Education_Mechanik_IdMechanik",
                        column: x => x.IdMechanik,
                        principalTable: "Mechanik",
                        principalColumn: "IdMechanik",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Repairs",
                columns: table => new
                {
                    IdRepair = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPlane = table.Column<int>(type: "int", nullable: false),
                    IdMechanik = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MechanikIdMechanik = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Repair_PK", x => x.IdRepair);
                    table.ForeignKey(
                        name: "FK_Repairs_Mechanik_MechanikIdMechanik",
                        column: x => x.MechanikIdMechanik,
                        principalTable: "Mechanik",
                        principalColumn: "IdMechanik",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Repairs_Plane_IdPlane",
                        column: x => x.IdPlane,
                        principalTable: "Plane",
                        principalColumn: "IdPlane",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    IdFlight = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    From = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    To = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Line = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    TakeOffDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LandingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdPlane = table.Column<int>(type: "int", nullable: false),
                    IdPilot1 = table.Column<int>(type: "int", nullable: false),
                    IdPilot2 = table.Column<int>(type: "int", nullable: false),
                    IdFlightParent = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Flight_PK", x => x.IdFlight);
                    table.ForeignKey(
                        name: "FK_Flights_Flights_IdFlightParent",
                        column: x => x.IdFlightParent,
                        principalTable: "Flights",
                        principalColumn: "IdFlight");
                    table.ForeignKey(
                        name: "FK_Flights_Plane_IdPlane",
                        column: x => x.IdPlane,
                        principalTable: "Plane",
                        principalColumn: "IdPlane");
                    table.ForeignKey(
                        name: "Flight_Pilot1",
                        column: x => x.IdPilot1,
                        principalTable: "Pilot",
                        principalColumn: "IdPilot");
                    table.ForeignKey(
                        name: "Flight_Pilot2",
                        column: x => x.IdPilot2,
                        principalTable: "Pilot",
                        principalColumn: "IdPilot");
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    IdTicket = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOrder = table.Column<int>(type: "int", nullable: false),
                    IdFlight = table.Column<int>(type: "int", nullable: false),
                    IdAirport = table.Column<int>(type: "int", nullable: false),
                    SeatsAmount = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Approved = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Class = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    BaggageType = table.Column<int>(type: "int", nullable: false),
                    Animals = table.Column<bool>(type: "bit", nullable: false),
                    AdditonalMeal = table.Column<bool>(type: "bit", nullable: false),
                    Seat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderIdOrder = table.Column<int>(type: "int", nullable: true),
                    FlightIdFlight = table.Column<int>(type: "int", nullable: true),
                    AirportIdAirport = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Ticket_PK", x => x.IdTicket);
                    table.ForeignKey(
                        name: "FK_Ticket_Airport_AirportIdAirport",
                        column: x => x.AirportIdAirport,
                        principalTable: "Airport",
                        principalColumn: "IdAirport",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticket_Flights_FlightIdFlight",
                        column: x => x.FlightIdFlight,
                        principalTable: "Flights",
                        principalColumn: "IdFlight",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticket_Order_OrderIdOrder",
                        column: x => x.OrderIdOrder,
                        principalTable: "Order",
                        principalColumn: "IdOrder",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ContactData",
                columns: new[] { "IdCD", "AppartmentNumber", "City", "Email", "PhoneNumber", "PostCode", "Street" },
                values: new object[,]
                {
                    { 3, null, "Warsaw", "warlot@pjwstk.edu.pl", "+4222222222", "01-000", "Warszawska" },
                    { 4, null, "Kiew", "kiewlot@pjwstk.edu.pl", "+433333333", "22323", "Kiewska" },
                    { 1, null, "Warsaw", "janko@pjwstk.edu.pl", "+4852525252", "01-355", "Koszykowa 86" },
                    { 2, null, "Admin", "admin@pjwstk.edu.pl", "+1111111111", "111111", "Admin" },
                    { 5, null, "Warsaw", "pilot1@pjwstk.edu.pl", "+4444444444", "22323", "Ulica im. Pilota1" },
                    { 6, null, "Kiew", "pilot2@pjwstk.edu.pl", "+4555555555", "01-355", "Ulica im. Pilota2" }
                });

            migrationBuilder.InsertData(
                table: "Airport",
                columns: new[] { "IdAirport", "IdCD", "Name", "NumberOfLines" },
                values: new object[,]
                {
                    { 1, 3, "Chopina", 8 },
                    { 2, 4, "Boryspil", 6 }
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "IdPerson", "IdCD", "IdEmp", "IdType", "Login", "Logined", "Name", "PESEL", "Password", "Salary", "Surname" },
                values: new object[,]
                {
                    { 1, 1, null, 1, "jan1", true, "Jan", null, "aboba", null, "Kowalski" },
                    { 2, 2, null, 3, "admin", true, "admin", null, "admin", null, "admin" }
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "IdPerson", "IdCD", "IdEmp", "IdType", "Login", "Name", "PESEL", "Password", "Salary", "Surname" },
                values: new object[,]
                {
                    { 3, 5, null, 2, null, "John", "1", null, 2000.0, "Smith" },
                    { 4, 6, null, 2, null, "Will", "2", null, 3000.0, "Davidson" }
                });

            migrationBuilder.InsertData(
                table: "Pilot",
                columns: new[] { "IdPilot", "IdPerson", "TotalPractice" },
                values: new object[,]
                {
                    { 1, 3, 10000 },
                    { 2, 4, 20000 }
                });

            migrationBuilder.InsertData(
                table: "Plane",
                columns: new[] { "IdPlane", "IdAirport", "LastRepair", "SeatsCount" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 6, 13, 0, 3, 47, 656, DateTimeKind.Local).AddTicks(3400), 200 },
                    { 2, 2, new DateTime(2021, 6, 13, 0, 3, 47, 656, DateTimeKind.Local).AddTicks(4860), 100 }
                });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "IdFlight", "From", "IdFlightParent", "IdPilot1", "IdPilot2", "IdPlane", "LandingDate", "Line", "Price", "TakeOffDate", "To" },
                values: new object[] { 1, "Warsaw", null, 1, 2, 1, new DateTime(2021, 6, 13, 0, 3, 47, 631, DateTimeKind.Local).AddTicks(6770), 1, 200.0, new DateTime(2021, 6, 13, 0, 0, 0, 0, DateTimeKind.Local), "Kiev" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "IdFlight", "From", "IdFlightParent", "IdPilot1", "IdPilot2", "IdPlane", "LandingDate", "Line", "Price", "TakeOffDate", "To" },
                values: new object[] { 2, "Kiev", null, 2, 1, 2, new DateTime(2021, 6, 13, 0, 3, 47, 631, DateTimeKind.Local).AddTicks(8495), 2, 100.0, new DateTime(2021, 6, 13, 0, 0, 0, 0, DateTimeKind.Local), "Warsaw" });

            migrationBuilder.CreateIndex(
                name: "IX_Airport_IdCD",
                table: "Airport",
                column: "IdCD",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Airport_Name",
                table: "Airport",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Education_IdMechanik",
                table: "Education",
                column: "IdMechanik");

            migrationBuilder.CreateIndex(
                name: "IX_Employment_IdAirport",
                table: "Employment",
                column: "IdAirport");

            migrationBuilder.CreateIndex(
                name: "IX_Employment_IdPerson_IdAirport",
                table: "Employment",
                columns: new[] { "IdPerson", "IdAirport" },
                unique: true,
                filter: "[IdPerson] IS NOT NULL AND [IdAirport] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_IdFlightParent",
                table: "Flights",
                column: "IdFlightParent");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_IdPilot1",
                table: "Flights",
                column: "IdPilot1");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_IdPilot2",
                table: "Flights",
                column: "IdPilot2");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_IdPlane",
                table: "Flights",
                column: "IdPlane");

            migrationBuilder.CreateIndex(
                name: "IX_Mechanik_IdPerson",
                table: "Mechanik",
                column: "IdPerson",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_IdPerson",
                table: "Order",
                column: "IdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_Person_IdCD",
                table: "Person",
                column: "IdCD",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_IdEmp",
                table: "Person",
                column: "IdEmp",
                unique: true,
                filter: "[IdEmp] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Person_Login",
                table: "Person",
                column: "Login",
                unique: true,
                filter: "[Login] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Person_PESEL",
                table: "Person",
                column: "PESEL",
                unique: true,
                filter: "[PESEL] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Pilot_IdPerson",
                table: "Pilot",
                column: "IdPerson",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plane_IdAirport",
                table: "Plane",
                column: "IdAirport");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_IdPlane",
                table: "Repairs",
                column: "IdPlane");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_MechanikIdMechanik",
                table: "Repairs",
                column: "MechanikIdMechanik");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_IdPerson",
                table: "Staff",
                column: "IdPerson",
                unique: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Education");

            migrationBuilder.DropTable(
                name: "Employment");

            migrationBuilder.DropTable(
                name: "Repairs");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Mechanik");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Plane");

            migrationBuilder.DropTable(
                name: "Pilot");

            migrationBuilder.DropTable(
                name: "Airport");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "ContactData");
        }
    }
}
