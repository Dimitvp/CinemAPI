using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Domain.Contracts.Models.Ticket;
using CinemAPI.Models.Contracts.Reservetion;
using CinemAPI.Models.Contracts.Ticket;

namespace CinemAPI.Domain.NewTicket
{
    public class NewTicketReservationValidation : INewTicket
    {
        private readonly IReservatioRepository reservationRepo;
        private readonly INewTicket newTicket;


        public NewTicketReservationValidation(INewTicket newTicket,  IReservatioRepository reservationRepo)
        {
            this.reservationRepo = reservationRepo;
            this.newTicket = newTicket;
        }

        public NewTicketSummery New(ITicketRequest ticket)
        {
            if (ticket.Guid != null)
            {
                IReservation reservation = reservationRepo.GetReservationByGuid(ticket.Guid);

                if (reservation == null)
                {
                    return new NewTicketSummery(false, $"There is someting wrong with this reservation code: {ticket.Guid}");
                }

                if (reservation.IsActive == false)
                {
                    return new NewTicketSummery(false, $"This reservation is canceled. It is either used or expired!");
                }

                return newTicket.New(new TicketWithReservationtModel(
                        reservation.ProjectionId,
                        reservation.Row,
                        reservation.Column                      
                    ));
            }

            return newTicket.New(ticket);
        }
    }
}