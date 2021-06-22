using MASP.Database;
using MASP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MASP.Services
{
    public class SqlServerDbService : ISqLServerService
    {
        private readonly SQLServerContext DB;

        public SqlServerDbService(SQLServerContext context)
        {
            DB = context;
        }

        public Order CreateTicket(int idPerson, Ticket ticket, int idOrder)
        {
            var order = DB.Order.Where(o => o.IdOrder == idOrder).FirstOrDefault(); 
            if (idOrder == 0)
            {
                order = new Order { IdPerson = idPerson };
                DB.Add(order);
                DB.SaveChanges();
            }
            try
            {
                ticket.IdOrder = order.IdOrder;
                DB.Add(ticket);
                DB.SaveChanges();

                return order;
            }
            catch (Exception)
            {
                if(idOrder == 0)
                {
                    DB.Remove(ticket);
                    DB.Remove(order);
                    DB.SaveChanges();
                }
                return null;
            }
            
        }
        



        public IEnumerable<Flight> GetFlights(string from, string to, DateTime? date)
        {
            var res = DB.Flights.Where(f=>f.IdFlight==f.IdFlight);
            if (from != null && from.Trim().Length > 0)
                res = res.Where(f => f.From.StartsWith(from));
            if(to != null && to.Trim().Length > 0)
                res = res.Where(f => f.To.StartsWith(to));
            if (date != null)
                res = res.Where(f => f.TakeOffDate.Date == date.Value.Date);
            return res.ToList();
        }

        public IEnumerable<Order> GetOrders(int IdPerson)
        {
            var orders = DB.Order.Where(o => o.IdPerson == IdPerson).ToList();
            foreach (var o in orders)
                o.TotalPrice = DB.Ticket.Where(t => o.IdOrder == t.IdOrder).Include(t => t.Flight).Sum(t => (t.Flight.Price*t.SeatsAmount));
            return orders;
        }

        public IEnumerable<Ticket> GetTickets(int idPerson, int idOrder)
        {
            var order = DB.Order.Where(o=>o.IdPerson == idPerson && o.IdOrder == idOrder).FirstOrDefault();
            if (order == null)
                return null;
            return DB.Ticket.Where(t => t.Order == order).Include(t=>t.Flight).ToList();
        }

        public Person Login(string login, string password)
        {
            var person = DB.Person.Where(p => p.Login == login && p.Password == password).Include(p=>p.ContactData).FirstOrDefault();
            Console.WriteLine(person);
            return person;
        }

        public Order PayReserve(int idPerson, int idOrder)
        {
            var order = DB.Order.Where(o => o.IdOrder == idOrder).FirstOrDefault();
            if (order == null || order.IdPerson != idPerson || order.Payed == true)
                return null;
            try
            {
                order.Payed = true;
                DB.SaveChanges();
                return order;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public Order PayFully(int idPerson , int idOrder)
        {
            var order = DB.Order.Where(o => o.IdOrder == idOrder ).FirstOrDefault();
            if (order == null || order.IdPerson != idPerson)
                return null;
            try
            {
                if(!order.Payed)
                    order.Payed = true;
                var tickets = DB.Ticket.Where(t => t.IdOrder == order.IdOrder);
                foreach (var t in tickets) {
                    if (t.Approved == true)
                        return null;
                    t.Approved = true;
                }
                DB.SaveChanges();
                return order;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
