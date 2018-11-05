using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.Reservetion;

namespace CinemAPI.Domain.NewReservation
{
    public class NewReservationSeatsValidation : INewReservation
    {
        private readonly INewReservation newReserv;

        public NewReservationSeatsValidation(INewReservation newReserv)
        {
            this.newReserv = newReserv;
        }

        public NewReservationSummery New(IReservationRequest reservation)
        {


            return newReserv.New(reservation);
        }
    }
}
