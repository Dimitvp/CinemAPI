using CinemAPI.Models.Contracts.Ticket;

namespace CinemAPI.Domain.Contracts.Models.Ticket
{
    public class TicketWithReservationtModel : ITicketRequest
    {
        public TicketWithReservationtModel(long projectionId, int row, int column)
        {
            this.ProjectionId = projectionId;
            this.Row = row;
            this.Column = column;
        }

        public long ProjectionId { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }

        public string Guid { get; set; }
    }
}
