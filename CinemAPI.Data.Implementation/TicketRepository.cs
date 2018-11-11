using System.Collections.Generic;
using System.Linq;
using CinemAPI.Data.EF;
using CinemAPI.Models;
using CinemAPI.Models.Contracts.Ticket;
using CinemAPI.Models.DTOs;

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
            return db.Projections
                .Where(p => p.Id == id)
                .Select(s => new TicketDTO
                {
                    ProjectionStartDate = s.StartDate,
                    MovieName = s.Movie.Name,
                    RoomNum = s.Room.Number,
                    CinemaName = s.Room.Cinema.Name
                })
                .Single();
        }

        public ITicket Insert(ITicketCreation ticket)
        {
            Ticket newTicket = new Ticket(
                ticket.ProjectionId,
                ticket.Guid,
                ticket.ProjectionStartDate,
                ticket.MovieName,
                ticket.CinemaName,
                ticket.RoomNum,
                ticket.Row,
                ticket.Column
                );
            db.Tickets.Add(newTicket);

            db.Projections
                .Where(p => p.Id == ticket.ProjectionId)
                .ToList()
                .ForEach(x => x.AvailableSeatsCount--);

            db.SaveChanges();
            return newTicket;
        }
    }
}
