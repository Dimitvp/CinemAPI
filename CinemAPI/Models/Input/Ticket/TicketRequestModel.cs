namespace CinemAPI.Models.Input.Ticket
{
    public class TicketRequestModel
    {
        public string ReservationGuid { get; set; }

        public long ProjectionId { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }
    }
}