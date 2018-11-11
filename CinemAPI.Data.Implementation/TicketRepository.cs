using System.Collections.Generic;
using CinemAPI.Data.EF;
using CinemAPI.Models.Contracts.Ticket;

namespace CinemAPI.Data.Implementation
{
    public class TicketRepository : ITicketRepository
    {
        private readonly CinemaDbContext db;

        public TicketRepository(CinemaDbContext db)
        {
            this.db = db;
        }

        public ITicket GetRestInfo(long id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITicket> GetRowsColsById(long id)
        {
            throw new System.NotImplementedException();
        }

        public ITicket Insert(ITicketCreation ticket)
        {
            throw new System.NotImplementedException();
        }
    }
}
