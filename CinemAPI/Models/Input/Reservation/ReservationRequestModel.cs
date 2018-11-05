namespace CinemAPI.Models.Input.Reservation
{
    public class ReservationRequestModel
    {
        public long ProjectionId { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }
    }
}