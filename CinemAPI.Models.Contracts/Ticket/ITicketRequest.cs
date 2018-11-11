namespace CinemAPI.Models.Contracts.Ticket
{
    public interface ITicketRequest
    {
        long ProjectionId { get; }

        int Row { get; }

        int Column { get; }
    }
}
