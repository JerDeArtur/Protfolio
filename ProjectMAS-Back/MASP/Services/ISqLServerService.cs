using MASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MASP.Services
{
    public interface ISqLServerService
    {
        public Person Login(string login, string password);
        public IEnumerable<Flight> GetFlights(string from, string to, DateTime? date);
        public IEnumerable<Ticket> GetTickets(int idPerson, int idOrder);
        public Order CreateTicket(int idPerson, Ticket ticket, int idOrder);
        public IEnumerable<Order> GetOrders(int IdPerson);
        public Order PayFully(int idPerson, int idOrder);
        public Order PayReserve(int idPerson, int idOrder);
    }
}
