using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Domain.Contracts.Models.Ticket;
using CinemAPI.Models;
using CinemAPI.Models.Contracts.Ticket;
using System;

namespace CinemAPI.Domain.NewTicket
{
    public class NewTicketCreation : INewTicket
    {
        private readonly ITicketRepository ticketRepo;

        public NewTicketCreation(ITicketRepository ticketRepo)
        {
            this.ticketRepo = ticketRepo;
        }

        public NewTicketSummery New(ITicketRequest ticketReq)
        {
            string newGuid = Guid.NewGuid().ToString("N").Substring(0,5);
            
            ITicket ticket = ticketRepo.GetRestInfo(ticketReq.ProjectionId);

            ITicket newTicket = ticketRepo.Insert(new Ticket(
                ticketReq.ProjectionId,
                newGuid,
                ticket.ProjectionStartDate,
                ticket.MovieName,
                ticket.CinemaName,
                ticket.RoomNum,
                ticketReq.Row,
                ticketReq.Column));

            //Creating the model for the Client
            ITicketSuccess ticketSuccess = new TicketModel(
                newGuid,
                ticket.ProjectionStartDate,
                ticket.MovieName,
                ticket.CinemaName,
                ticket.RoomNum,
                ticketReq.Row,
                ticketReq.Column
                );

            return new NewTicketSummery(true, ticketSuccess);
        }
    }
}
