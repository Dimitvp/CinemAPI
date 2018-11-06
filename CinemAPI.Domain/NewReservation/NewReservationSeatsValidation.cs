using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.Reservetion;
using System.Collections.Generic;

namespace CinemAPI.Domain.NewReservation
{
    public class NewReservationSeatsValidation : INewReservation
    {
        private readonly INewReservation newReserv;
        private readonly IReservatioRepository reservationRepo;

        public NewReservationSeatsValidation(INewReservation newReserv, IReservatioRepository reservationRepo)
        {
            this.newReserv = newReserv;
            this.reservationRepo = reservationRepo;
        }

        public NewReservationSummery New(IReservationRequest reservation)
        {
            IEnumerable<IReservation> reservationsSits = reservationRepo.GetRowsColsById(reservation.ProjectionId);

            foreach (var reserv in reservationsSits)
            {
                if (reservation.Row == reserv.Row && reservation.Column == reserv.Column)
                {
                    return new NewReservationSummery(false, "This seat is already taken!");
                }
            }

            return newReserv.New(reservation);
        }
    }
}
