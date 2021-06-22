﻿// <auto-generated />
using System;
using MASP.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MASP.Migrations
{
    [DbContext(typeof(SQLServerContext))]
    [Migration("20210613003017_ss4")]
    partial class ss4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MASP.Models.Airport", b =>
                {
                    b.Property<int>("IdAirport")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdCD")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("NumberOfLines")
                        .HasColumnType("int");

                    b.HasKey("IdAirport")
                        .HasName("Airport_PK");

                    b.HasIndex("IdCD")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Airport");

                    b.HasData(
                        new
                        {
                            IdAirport = 2,
                            IdCD = 4,
                            Name = "Boryspil",
                            NumberOfLines = 6
                        },
                        new
                        {
                            IdAirport = 1,
                            IdCD = 3,
                            Name = "Chopina",
                            NumberOfLines = 8
                        });
                });

            modelBuilder.Entity("MASP.Models.ContactData", b =>
                {
                    b.Property<int>("IdCD")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AppartmentNumber")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdCD")
                        .HasName("CD_PK");

                    b.ToTable("ContactData");

                    b.HasData(
                        new
                        {
                            IdCD = 3,
                            City = "Warsaw",
                            Email = "warlot@pjwstk.edu.pl",
                            PhoneNumber = "+4222222222",
                            PostCode = "01-000",
                            Street = "Warszawska"
                        },
                        new
                        {
                            IdCD = 4,
                            City = "Kiew",
                            Email = "kiewlot@pjwstk.edu.pl",
                            PhoneNumber = "+433333333",
                            PostCode = "22323",
                            Street = "Kiewska"
                        },
                        new
                        {
                            IdCD = 1,
                            City = "Warsaw",
                            Email = "janko@pjwstk.edu.pl",
                            PhoneNumber = "+4852525252",
                            PostCode = "01-355",
                            Street = "Koszykowa 86"
                        },
                        new
                        {
                            IdCD = 2,
                            City = "Admin",
                            Email = "admin@pjwstk.edu.pl",
                            PhoneNumber = "+1111111111",
                            PostCode = "111111",
                            Street = "Admin"
                        },
                        new
                        {
                            IdCD = 5,
                            City = "Warsaw",
                            Email = "pilot1@pjwstk.edu.pl",
                            PhoneNumber = "+4444444444",
                            PostCode = "22323",
                            Street = "Ulica im. Pilota1"
                        },
                        new
                        {
                            IdCD = 6,
                            City = "Kiew",
                            Email = "pilot2@pjwstk.edu.pl",
                            PhoneNumber = "+4555555555",
                            PostCode = "01-355",
                            Street = "Ulica im. Pilota2"
                        });
                });

            modelBuilder.Entity("MASP.Models.Education", b =>
                {
                    b.Property<int>("IdEducation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Grade")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("IdMechanik")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("University")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("IdEducation")
                        .HasName("Education_PK");

                    b.HasIndex("IdMechanik");

                    b.ToTable("Education");
                });

            modelBuilder.Entity("MASP.Models.Employment", b =>
                {
                    b.Property<int>("IdEmployment")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Characteristics")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdAirport")
                        .HasColumnType("int");

                    b.Property<int?>("IdPerson")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Retire")
                        .HasColumnType("datetime2");

                    b.HasKey("IdEmployment")
                        .HasName("Employment_PK");

                    b.HasIndex("IdAirport");

                    b.HasIndex("IdPerson", "IdAirport")
                        .IsUnique()
                        .HasFilter("[IdPerson] IS NOT NULL AND [IdAirport] IS NOT NULL");

                    b.ToTable("Employment");
                });

            modelBuilder.Entity("MASP.Models.Flight", b =>
                {
                    b.Property<int>("IdFlight")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("From")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("IdFlightParent")
                        .HasColumnType("int");

                    b.Property<int>("IdPilot1")
                        .HasColumnType("int");

                    b.Property<int>("IdPilot2")
                        .HasColumnType("int");

                    b.Property<int>("IdPlane")
                        .HasColumnType("int");

                    b.Property<DateTime>("LandingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Line")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime>("TakeOffDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("To")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("IdFlight")
                        .HasName("Flight_PK");

                    b.HasIndex("IdFlightParent");

                    b.HasIndex("IdPilot1");

                    b.HasIndex("IdPilot2");

                    b.HasIndex("IdPlane");

                    b.ToTable("Flights");

                    b.HasData(
                        new
                        {
                            IdFlight = 1,
                            From = "Warsaw",
                            IdPilot1 = 1,
                            IdPilot2 = 2,
                            IdPlane = 1,
                            LandingDate = new DateTime(2021, 6, 13, 0, 0, 0, 0, DateTimeKind.Local),
                            Line = 1,
                            Price = 200.0,
                            TakeOffDate = new DateTime(2021, 6, 13, 0, 0, 0, 0, DateTimeKind.Local),
                            To = "Kiev"
                        },
                        new
                        {
                            IdFlight = 2,
                            From = "Kiev",
                            IdPilot1 = 2,
                            IdPilot2 = 1,
                            IdPlane = 2,
                            LandingDate = new DateTime(2021, 6, 13, 0, 0, 0, 0, DateTimeKind.Local),
                            Line = 2,
                            Price = 100.0,
                            TakeOffDate = new DateTime(2021, 6, 13, 0, 0, 0, 0, DateTimeKind.Local),
                            To = "Warsaw"
                        });
                });

            modelBuilder.Entity("MASP.Models.Mechanik", b =>
                {
                    b.Property<int>("IdMechanik")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdPerson")
                        .HasColumnType("int");

                    b.Property<int>("MonthlyRepairs")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("IdMechanik")
                        .HasName("Mechanik_PK");

                    b.HasIndex("IdPerson")
                        .IsUnique();

                    b.ToTable("Mechanik");
                });

            modelBuilder.Entity("MASP.Models.Order", b =>
                {
                    b.Property<int>("IdOrder")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("IdPerson")
                        .HasColumnType("int");

                    b.Property<bool>("Payed")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("IdOrder")
                        .HasName("Order_PK");

                    b.HasIndex("IdPerson");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("MASP.Models.Person", b =>
                {
                    b.Property<int>("IdPerson")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdCD")
                        .HasColumnType("int");

                    b.Property<int?>("IdEmp")
                        .HasColumnType("int");

                    b.Property<int>("IdType")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("Logined")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PESEL")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<double?>("Salary")
                        .HasColumnType("float");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdPerson")
                        .HasName("Person_PK");

                    b.HasIndex("IdCD")
                        .IsUnique();

                    b.HasIndex("IdEmp")
                        .IsUnique()
                        .HasFilter("[IdEmp] IS NOT NULL");

                    b.HasIndex("Login")
                        .IsUnique()
                        .HasFilter("[Login] IS NOT NULL");

                    b.HasIndex("PESEL")
                        .IsUnique()
                        .HasFilter("[PESEL] IS NOT NULL");

                    b.ToTable("Person");

                    b.HasData(
                        new
                        {
                            IdPerson = 1,
                            IdCD = 1,
                            IdType = 1,
                            Login = "jan1",
                            Logined = true,
                            Name = "Jan",
                            Password = "aboba",
                            Surname = "Kowalski"
                        },
                        new
                        {
                            IdPerson = 2,
                            IdCD = 2,
                            IdType = 3,
                            Login = "admin",
                            Logined = true,
                            Name = "admin",
                            Password = "admin",
                            Surname = "admin"
                        },
                        new
                        {
                            IdPerson = 3,
                            IdCD = 5,
                            IdType = 2,
                            Logined = false,
                            Name = "John",
                            PESEL = "1",
                            Salary = 2000.0,
                            Surname = "Smith"
                        },
                        new
                        {
                            IdPerson = 4,
                            IdCD = 6,
                            IdType = 2,
                            Logined = false,
                            Name = "Will",
                            PESEL = "2",
                            Salary = 3000.0,
                            Surname = "Davidson"
                        });
                });

            modelBuilder.Entity("MASP.Models.Pilot", b =>
                {
                    b.Property<int>("IdPilot")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdPerson")
                        .HasColumnType("int");

                    b.Property<int>("MonthlyFlights")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("TotalPractice")
                        .HasColumnType("int");

                    b.HasKey("IdPilot")
                        .HasName("Pilot_PK");

                    b.HasIndex("IdPerson")
                        .IsUnique();

                    b.ToTable("Pilot");

                    b.HasData(
                        new
                        {
                            IdPilot = 1,
                            IdPerson = 3,
                            MonthlyFlights = 0,
                            TotalPractice = 10000
                        },
                        new
                        {
                            IdPilot = 2,
                            IdPerson = 4,
                            MonthlyFlights = 0,
                            TotalPractice = 20000
                        });
                });

            modelBuilder.Entity("MASP.Models.Plane", b =>
                {
                    b.Property<int>("IdPlane")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdAirport")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastRepair")
                        .HasColumnType("datetime2");

                    b.Property<int>("SeatsCount")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasDefaultValue("Ready");

                    b.HasKey("IdPlane")
                        .HasName("Plane_PK");

                    b.HasIndex("IdAirport");

                    b.ToTable("Plane");

                    b.HasData(
                        new
                        {
                            IdPlane = 1,
                            IdAirport = 1,
                            LastRepair = new DateTime(2021, 6, 13, 2, 30, 17, 173, DateTimeKind.Local).AddTicks(4725),
                            SeatsCount = 200
                        },
                        new
                        {
                            IdPlane = 2,
                            IdAirport = 2,
                            LastRepair = new DateTime(2021, 6, 13, 2, 30, 17, 173, DateTimeKind.Local).AddTicks(5689),
                            SeatsCount = 100
                        });
                });

            modelBuilder.Entity("MASP.Models.Repair", b =>
                {
                    b.Property<int>("IdRepair")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("IdMechanik")
                        .HasColumnType("int");

                    b.Property<int>("IdPlane")
                        .HasColumnType("int");

                    b.Property<int?>("MechanikIdMechanik")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdRepair")
                        .HasName("Repair_PK");

                    b.HasIndex("IdPlane");

                    b.HasIndex("MechanikIdMechanik");

                    b.ToTable("Repairs");
                });

            modelBuilder.Entity("MASP.Models.Staff", b =>
                {
                    b.Property<int>("IdStaff")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdPerson")
                        .HasColumnType("int");

                    b.Property<int>("WeeklyWorkTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("IdStaff")
                        .HasName("Staff_PK");

                    b.HasIndex("IdPerson")
                        .IsUnique();

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("MASP.Models.Ticket", b =>
                {
                    b.Property<int>("IdTicket")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AdditonalMeal")
                        .HasColumnType("bit");

                    b.Property<bool>("Animals")
                        .HasColumnType("bit");

                    b.Property<bool>("Approved")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("BaggageType")
                        .HasColumnType("int");

                    b.Property<string>("Class")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("IdAirport")
                        .HasColumnType("int");

                    b.Property<int>("IdFlight")
                        .HasColumnType("int");

                    b.Property<int>("IdOrder")
                        .HasColumnType("int");

                    b.Property<string>("Seat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeatsAmount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.HasKey("IdTicket")
                        .HasName("Ticket_PK");

                    b.HasIndex("IdAirport");

                    b.HasIndex("IdFlight");

                    b.HasIndex("IdOrder");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("MASP.Models.Airport", b =>
                {
                    b.HasOne("MASP.Models.ContactData", "ContactData")
                        .WithOne("Airport")
                        .HasForeignKey("MASP.Models.Airport", "IdCD")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContactData");
                });

            modelBuilder.Entity("MASP.Models.Education", b =>
                {
                    b.HasOne("MASP.Models.Mechanik", "Mechanik")
                        .WithMany("Educations")
                        .HasForeignKey("IdMechanik")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mechanik");
                });

            modelBuilder.Entity("MASP.Models.Employment", b =>
                {
                    b.HasOne("MASP.Models.Airport", "Airport")
                        .WithMany("Employments")
                        .HasForeignKey("IdAirport")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("MASP.Models.Person", "Person")
                        .WithMany("Employments")
                        .HasForeignKey("IdPerson")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Airport");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("MASP.Models.Flight", b =>
                {
                    b.HasOne("MASP.Models.Flight", "FlightParent")
                        .WithMany("FlightsChild")
                        .HasForeignKey("IdFlightParent")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("MASP.Models.Pilot", "Pilot1")
                        .WithMany("FlightsAs1")
                        .HasForeignKey("IdPilot1")
                        .HasConstraintName("Flight_Pilot1")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MASP.Models.Pilot", "Pilot2")
                        .WithMany("FlightsAs2")
                        .HasForeignKey("IdPilot2")
                        .HasConstraintName("Flight_Pilot2")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MASP.Models.Plane", "Plane")
                        .WithMany("Flights")
                        .HasForeignKey("IdPlane")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("FlightParent");

                    b.Navigation("Pilot1");

                    b.Navigation("Pilot2");

                    b.Navigation("Plane");
                });

            modelBuilder.Entity("MASP.Models.Mechanik", b =>
                {
                    b.HasOne("MASP.Models.Person", "Person")
                        .WithOne("Mechanik")
                        .HasForeignKey("MASP.Models.Mechanik", "IdPerson")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("MASP.Models.Order", b =>
                {
                    b.HasOne("MASP.Models.Person", "Person")
                        .WithMany("Orders")
                        .HasForeignKey("IdPerson")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("MASP.Models.Person", b =>
                {
                    b.HasOne("MASP.Models.ContactData", "ContactData")
                        .WithOne("Person")
                        .HasForeignKey("MASP.Models.Person", "IdCD")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContactData");
                });

            modelBuilder.Entity("MASP.Models.Pilot", b =>
                {
                    b.HasOne("MASP.Models.Person", "Person")
                        .WithOne("Pilot")
                        .HasForeignKey("MASP.Models.Pilot", "IdPerson")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("MASP.Models.Plane", b =>
                {
                    b.HasOne("MASP.Models.Airport", "Airport")
                        .WithMany("Planes")
                        .HasForeignKey("IdAirport")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Airport");
                });

            modelBuilder.Entity("MASP.Models.Repair", b =>
                {
                    b.HasOne("MASP.Models.Plane", "Plane")
                        .WithMany("Repairs")
                        .HasForeignKey("IdPlane")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MASP.Models.Mechanik", "Mechanik")
                        .WithMany("Repairs")
                        .HasForeignKey("MechanikIdMechanik");

                    b.Navigation("Mechanik");

                    b.Navigation("Plane");
                });

            modelBuilder.Entity("MASP.Models.Staff", b =>
                {
                    b.HasOne("MASP.Models.Person", "Person")
                        .WithOne("Staff")
                        .HasForeignKey("MASP.Models.Staff", "IdPerson")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("MASP.Models.Ticket", b =>
                {
                    b.HasOne("MASP.Models.Airport", "Airport")
                        .WithMany("Tickets")
                        .HasForeignKey("IdAirport")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MASP.Models.Flight", "Flight")
                        .WithMany("Tickets")
                        .HasForeignKey("IdFlight")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MASP.Models.Order", "Order")
                        .WithMany("Tickets")
                        .HasForeignKey("IdOrder")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Airport");

                    b.Navigation("Flight");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("MASP.Models.Airport", b =>
                {
                    b.Navigation("Employments");

                    b.Navigation("Planes");

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("MASP.Models.ContactData", b =>
                {
                    b.Navigation("Airport");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("MASP.Models.Flight", b =>
                {
                    b.Navigation("FlightsChild");

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("MASP.Models.Mechanik", b =>
                {
                    b.Navigation("Educations");

                    b.Navigation("Repairs");
                });

            modelBuilder.Entity("MASP.Models.Order", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("MASP.Models.Person", b =>
                {
                    b.Navigation("Employments");

                    b.Navigation("Mechanik");

                    b.Navigation("Orders");

                    b.Navigation("Pilot");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("MASP.Models.Pilot", b =>
                {
                    b.Navigation("FlightsAs1");

                    b.Navigation("FlightsAs2");
                });

            modelBuilder.Entity("MASP.Models.Plane", b =>
                {
                    b.Navigation("Flights");

                    b.Navigation("Repairs");
                });
#pragma warning restore 612, 618
        }
    }
}
