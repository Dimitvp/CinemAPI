using CinemAPI.Models.Contracts.Reservetion;

namespace CinemAPI.Domain.Contracts.Models
{
    public class NewReservationSummery
    {
        public NewReservationSummery(bool isCreated)
        {
            this.IsCreated = isCreated;
        }

        public NewReservationSummery(bool isCreated, IReservationTicket reservationTicket)
        {
            this.IsCreated = isCreated;
            this.ReservationTicket = reservationTicket;
        }


        public NewReservationSummery(bool status, string msg)
            : this(status)
        {
            this.Message = msg;
        }

        public string Message { get; set; }

        public bool IsCreated { get; set; }

        public IReservationTicket ReservationTicket { get; }

    }
}
