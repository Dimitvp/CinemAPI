using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models;
using CinemAPI.Models.Contracts.Ticket;
using System;

namespace CinemAPI.Domain.NewTicket
{
    public class NewTicketCreation : INewTicket
    {
        private readonly ITicketRepository ticketRepo;
        private readonly IReservatioRepository reservationRepo;



        public NewTicketSummery New(ITicketRequest ticketReq)
        {
            string newGuid = Guid.NewGuid().ToString("N");
            ITicket ticket = ticketRepo.GetRestInfo(ticketReq.ProjectionId);

            ITicket newTicket = ticketRepo.Insert(new Ticket(
                ticket.ProjectionId,
                newGuid,
                ticket.ProjectionStartDate,
                ticket.MovieName,
                ticket.CinemaName,
                ticket.RoomNum,
                ticketReq.Row,
                ticketReq.Column));

            IReservationTicket reservetionTicket = new ReservationTicketModel(
                newGuid,
                reservation.ProjectionStartDate,
                reservation.MovieName,
                reservation.CinemaName,
                reservation.RoomNum,
                reservationReq.Row,
                reservationReq.Column
                );

            return new NewReservationSummery(true, reservetionTicket);
        }
    }
}
