using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.Reservetion;

namespace CinemAPI.Domain.NewReservation
{
    public class NewReservationValidation : INewReservation
    {
        private readonly INewReservation newReserv;
        private readonly IReservatioRepository reservationRepo;

        public NewReservationValidation(INewReservation newReserv, IReservatioRepository reservationRepo)
        {
            this.newReserv = newReserv;
            this.reservationRepo = reservationRepo;
        }

        public NewReservationSummery New(IReservationRequest reservation)
        {
            reservationRepo.CancelReservation(reservation);

            return newReserv.New(reservation);
        }
    }
}
