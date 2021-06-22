using MASP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MASP.Database
{
    public class SQLServerContext : DbContext
    {
        public DbSet<Airport>  Airport { set; get; }
        public DbSet<ContactData> ContactData { set; get; }
        public DbSet<Education> Education { set; get; }
        public DbSet<Employment> Employment { set; get; }
        public DbSet<Flight> Flights { set; get; }
        public DbSet<Mechanik> Mechanik { set; get; }
        public DbSet<Order> Order { set; get; }
        public DbSet<Person> Person { set; get; }
        public DbSet<Pilot> Pilot { set; get; }
        public DbSet<Plane> Plane { set; get; }
        public DbSet<Repair> Repairs { set; get; }
        public DbSet<Staff> Staff { set; get; }
        public DbSet<Ticket> Ticket { set; get; }

        public SQLServerContext(DbContextOptions<SQLServerContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airport>(entity => {
                entity.HasKey(e => e.IdAirport).HasName("Airport_PK");
                entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
                entity.Property(e => e.NumberOfLines).IsRequired();
                entity.HasOne(e => e.ContactData).WithOne(cd => cd.Airport).HasForeignKey<Airport>(a => a.IdCD);
                entity.HasIndex(e => e.Name).IsUnique();

                var tmp = new List<Airport>();
                tmp.Add(new Airport { IdAirport = 2, IdCD = 4, Name = "Boryspil", NumberOfLines = 6, });
                tmp.Add(new Airport {IdAirport=1,IdCD=3,Name="Chopina",NumberOfLines=8,});
                entity.HasData(tmp);
            });
            modelBuilder.Entity<ContactData>(entity => {
                entity.HasKey(e => e.IdCD).HasName("CD_PK");
                entity.Property(e => e.PhoneNumber).HasMaxLength(20).IsRequired();
                entity.Property(e => e.Email).HasMaxLength(100).IsRequired();
                entity.Property(e => e.PostCode).HasMaxLength(20).IsRequired();
                entity.Property(e => e.City).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Street).HasMaxLength(100).IsRequired();


                var tmp = new List<ContactData>();
                tmp.Add(new ContactData { IdCD = 3, Email = "warlot@pjwstk.edu.pl", PhoneNumber = "+4222222222", PostCode = "01-000", City = "Warsaw", Street = "Warszawska" });
                tmp.Add(new ContactData { IdCD = 4, Email = "kiewlot@pjwstk.edu.pl", PhoneNumber = "+433333333", PostCode = "22323", City = "Kiew", Street = "Kiewska" });
                tmp.Add(new ContactData { IdCD = 1, Email = "janko@pjwstk.edu.pl", PhoneNumber = "+4852525252", PostCode = "01-355", City = "Warsaw", Street = "Koszykowa 86" });
                tmp.Add(new ContactData { IdCD = 2, Email = "admin@pjwstk.edu.pl", PhoneNumber = "+1111111111", PostCode = "111111", City = "Admin", Street = "Admin" });
                tmp.Add(new ContactData { IdCD = 5, Email = "pilot1@pjwstk.edu.pl", PhoneNumber = "+4444444444", PostCode = "22323", City = "Warsaw", Street = "Ulica im. Pilota1" });
                tmp.Add(new ContactData { IdCD = 6, Email = "pilot2@pjwstk.edu.pl", PhoneNumber = "+4555555555", PostCode = "01-355", City = "Kiew", Street = "Ulica im. Pilota2" });
                entity.HasData(tmp);
            });
            modelBuilder.Entity<Education>(entity => {
                entity.HasKey(e => e.IdEducation).HasName("Education_PK");
                entity.Property(e => e.Name).HasMaxLength(150).IsRequired();
                entity.Property(e => e.University).HasMaxLength(150);
                entity.Property(e => e.Grade).HasMaxLength(100);
                entity.HasOne(e => e.Mechanik).WithMany(m => m.Educations).HasForeignKey(e => e.IdMechanik);

                /*var tmp = new List<Patient>();
                tmp.Add(new Patient { Birthdate = DateTime.Today, FirstName = "Bill", LastName = "Rodgers", IdPatient = 3 });
                entity.HasData(tmp);*/
            });
            modelBuilder.Entity<Employment>(entity => {
                entity.HasKey(e => e.IdEmployment).HasName("Employment_PK");
                entity.Property(e => e.HireDate).IsRequired();
                entity.Property(e => e.Characteristics).HasMaxLength(300);
                entity.HasOne(e => e.Person).WithMany(p => p.Employments).HasForeignKey(e => e.IdPerson).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(e => e.Airport).WithMany(a => a.Employments).HasForeignKey(e => e.IdAirport).OnDelete(DeleteBehavior.NoAction);
                entity.HasIndex(e => new { e.IdPerson, e.IdAirport }).IsUnique();

                /*var tmp = new List<Patient>();
                tmp.Add(new Patient { Birthdate = DateTime.Today, FirstName = "Bill", LastName = "Rodgers", IdPatient = 3 });
                entity.HasData(tmp);*/
            });
            modelBuilder.Entity<Flight>(entity => {
                entity.HasKey(e => e.IdFlight).HasName("Flight_PK");
                entity.Property(e => e.Price).IsRequired();
                entity.Property(e => e.TakeOffDate).IsRequired();
                entity.Property(e => e.LandingDate).IsRequired();
                entity.Property(e => e.From).HasMaxLength(200).IsRequired();
                entity.Property(e => e.To).HasMaxLength(200).IsRequired();
                entity.Property(e => e.Line).IsRequired();
                entity.HasMany(e => e.FlightsChild).WithOne(e => e.FlightParent).HasForeignKey(e => e.IdFlightParent).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(e => e.Pilot1).WithMany(p1 => p1.FlightsAs1).HasForeignKey(e => e.IdPilot1).HasConstraintName("Flight_Pilot1").OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(e => e.Pilot2).WithMany(p2 => p2.FlightsAs2).HasForeignKey(e => e.IdPilot2).HasConstraintName("Flight_Pilot2").OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(e => e.Plane).WithMany(p => p.Flights).HasForeignKey(e => e.IdPlane).OnDelete(DeleteBehavior.NoAction);

                var tmp = new List<Flight>();
                tmp.Add(new Flight { IdFlight = 1, From = "Warsaw", To = "Kiev", Line = 1, Price = 200, TakeOffDate = DateTime.Now.Date, LandingDate = DateTime.Now.Date, IdPlane = 1, IdPilot1 = 1, IdPilot2 = 2 });
                tmp.Add(new Flight { IdFlight = 2, From = "Kiev", To = "Warsaw", Line = 2, Price = 100, TakeOffDate = DateTime.Now.Date, LandingDate = DateTime.Now.Date, IdPlane = 2, IdPilot1 = 2, IdPilot2 = 1 });
                entity.HasData(tmp);
            });
            modelBuilder.Entity<Mechanik>(entity => {
                entity.HasKey(e => e.IdMechanik).HasName("Mechanik_PK");
                entity.Property(e => e.MonthlyRepairs).HasDefaultValue(0);
                entity.HasOne(e => e.Person).WithOne(p => p.Mechanik).HasForeignKey<Mechanik>(e => e.IdPerson) ;


                /*var tmp = new List<Patient>();
                tmp.Add(new Patient { Birthdate = DateTime.Today, FirstName = "Bill", LastName = "Rodgers", IdPatient = 3 });
                entity.HasData(tmp);*/
            });
            modelBuilder.Entity<Order>(entity => {
                entity.HasKey(e => e.IdOrder).HasName("Order_PK");
                entity.Property(e => e.CreationDate).HasDefaultValueSql("getdate()");
                entity.Property(e => e.Payed).HasDefaultValue(false);
                entity.HasOne(e => e.Person).WithMany(p => p.Orders).HasForeignKey(e => e.IdPerson) ;

                /*var tmp = new List<Patient>();
                tmp.Add(new Patient { Birthdate = DateTime.Today, FirstName = "Bill", LastName = "Rodgers", IdPatient = 3 });
                entity.HasData(tmp);*/
            });
            modelBuilder.Entity<Person>(entity => {
                entity.HasKey(e => e.IdPerson).HasName("Person_PK");
                entity.Property(e => e.Name).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Surname).HasMaxLength(100).IsRequired();
                entity.Property(e => e.PESEL).HasMaxLength(20);
                entity.Property(e => e.Login).HasMaxLength(30);
                entity.Property(e => e.Password).HasMaxLength(30);
                entity.Property(e => e.Logined).HasDefaultValue(false);
                entity.Property(e => e.IdType).IsRequired();

                entity.HasIndex(e => e.IdEmp).IsUnique();
                entity.HasIndex(e => e.Login).IsUnique();
                entity.HasOne(e => e.ContactData).WithOne(cd => cd.Person).HasForeignKey<Person>(e => e.IdCD);
                entity.HasIndex(e => e.PESEL).IsUnique();

                var tmp = new List<Person>();
                tmp.Add(new Person { IdPerson = 1,Name="Jan",Surname = "Kowalski",Login = "jan1", Password = "aboba", IdType = 1, Logined = true, IdCD = 1});
                tmp.Add(new Person { IdPerson = 2, Name = "admin", Surname = "admin", Login = "admin", Password = "admin", IdType = 3, Logined = true, IdCD = 2});
                tmp.Add(new Person { IdPerson = 3,Name="John",Surname = "Smith", IdType = 2, IdCD = 5,PESEL="1",Salary=2000});
                tmp.Add(new Person { IdPerson = 4, Name = "Will", Surname = "Davidson", IdType = 2, IdCD = 6, PESEL = "2", Salary = 3000 });
                //tmp.Add(new Person { IdPerson = 2, Name = "admin", Surname = "admin", Login = "admin", Password = "admin", IdType = 3, Logined = true, IdCD = 2 });
                //tmp.Add(new Person { IdPerson = 1, Name = "Jan", Surname = "Kowalski", Login = "jan1", Password = "aboba", IdType = 1, Logined = true, IdCD = 1 });

                entity.HasData(tmp);
            });
            modelBuilder.Entity<Pilot>(entity => {
                entity.HasKey(e => e.IdPilot).HasName("Pilot_PK");
                entity.Property(e => e.TotalPractice).IsRequired();
                entity.Property(e => e.MonthlyFlights).HasDefaultValue(0);
                entity.HasOne(e => e.Person).WithOne(p => p.Pilot).HasForeignKey<Pilot>(e => e.IdPerson);

                var tmp = new List<Pilot>();
                tmp.Add(new Pilot { IdPilot = 1, IdPerson = 3, TotalPractice = 10000 });
                tmp.Add(new Pilot { IdPilot = 2, IdPerson = 4, TotalPractice = 20000 });
                entity.HasData(tmp);
            });
            modelBuilder.Entity<Plane>(entity => {
                entity.HasKey(e => e.IdPlane).HasName("Plane_PK");
                entity.Property(e => e.LastRepair).IsRequired();
                entity.Property(e => e.SeatsCount).IsRequired();
                entity.Property(e => e.State).HasMaxLength(20).HasDefaultValue("Ready");
                entity.HasOne(e => e.Airport).WithMany(a => a.Planes).HasForeignKey(e => e.IdAirport);

                var tmp = new List<Plane>();
                tmp.Add(new Plane {IdPlane = 1,IdAirport=1,LastRepair=DateTime.Now,SeatsCount=200});
                tmp.Add(new Plane { IdPlane = 2, IdAirport = 2, LastRepair = DateTime.Now, SeatsCount = 100 });
                entity.HasData(tmp);
            });
            modelBuilder.Entity<Repair>(entity => {
                entity.HasKey(e => e.IdRepair).HasName("Repair_PK");
                entity.Property(e => e.Date).IsRequired();
                entity.Property(e => e.Duration).IsRequired();
                entity.Property(e => e.Type).IsRequired();
                entity.HasOne(e => e.Plane).WithMany(p => p.Repairs).HasForeignKey(e => e.IdPlane);
                entity.HasOne(e => e.Mechanik).WithMany(m => m.Repairs);

                /*var tmp = new List<Patient>();
                tmp.Add(new Patient { Birthdate = DateTime.Today, FirstName = "Bill", LastName = "Rodgers", IdPatient = 3 });
                entity.HasData(tmp);*/
            });
            modelBuilder.Entity<Staff>(entity => {
                entity.HasKey(e => e.IdStaff).HasName("Staff_PK");
                entity.Property(e => e.WeeklyWorkTime).HasDefaultValue(0);
                entity.HasOne(e => e.Person).WithOne(p => p.Staff).HasForeignKey<Staff>(e => e.IdPerson);

                /*var tmp = new List<Patient>();
                tmp.Add(new Patient { Birthdate = DateTime.Today, FirstName = "Bill", LastName = "Rodgers", IdPatient = 3 });
                entity.HasData(tmp);*/
            });
            modelBuilder.Entity<Ticket>(entity => {
                entity.HasKey(e => e.IdTicket).HasName("Ticket_PK");
                entity.Property(e => e.SeatsAmount).HasDefaultValue(1);
                entity.Property(e => e.Approved).HasDefaultValue(false);
                entity.Property(e => e.Class).HasMaxLength(30).IsRequired();
                entity.Property(e => e.BaggageType).IsRequired();
                entity.Property(e => e.Animals).IsRequired();
                entity.Property(e => e.AdditonalMeal).IsRequired();
                entity.Property(e => e.Seat).IsRequired();
                entity.HasOne(e => e.Flight).WithMany(f => f.Tickets).HasForeignKey(e => e.IdFlight).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(e => e.Airport).WithMany(a => a.Tickets).HasForeignKey(e => e.IdAirport).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(e => e.Order).WithMany(o => o.Tickets).HasForeignKey(e => e.IdOrder).OnDelete(DeleteBehavior.NoAction);

                /*var tmp = new List<Patient>();
                tmp.Add(new Patient { Birthdate = DateTime.Today, FirstName = "Bill", LastName = "Rodgers", IdPatient = 3 });
                entity.HasData(tmp);*/
            });

        }
    }
}
