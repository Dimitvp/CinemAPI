using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.Reservetion;
using CinemAPI.Models.Contracts.Ticket;
using System.Collections.Generic;

namespace CinemAPI.Domain.NewTicket
{
    public class NewTicketSeatsValidation : INewTicket
    {
        private readonly ITicketRepository ticketRepo;
        private readonly IReservatioRepository reservationRepo;
        private readonly INewTicket newTicket;


        public NewTicketSeatsValidation(INewTicket newTicket, ITicketRepository ticketRepo, IReservatioRepository reservationRepo)
        {
            this.reservationRepo = reservationRepo;
            this.ticketRepo = ticketRepo;
            this.newTicket = newTicket;
        }

        public NewTicketSummery New(ITicketRequest ticket)
        {
            if (ticket.Guid == null)
            {
                IEnumerable<ITicket> boughtSites = ticketRepo.BoughtSeats(ticket.ProjectionId);

                IEnumerable<IReservation> reservationsSits = reservationRepo.GetRowsColsById(ticket.ProjectionId);

                foreach (var sit in boughtSites)
                {
                    if (ticket.Row == sit.Row && ticket.Column == sit.Column)
                    {
                        return new NewTicketSummery(false, "This seat is already taken!");

                    }
                }

                foreach (var reserv in reservationsSits)
                {
                    if (ticket.Row == reserv.Row && ticket.Column == reserv.Column)
                    {
                        return new NewTicketSummery(false, "This seat is Reserved!");
                    }
                }
            }
            return newTicket.New(ticket);
        }
    }
}
