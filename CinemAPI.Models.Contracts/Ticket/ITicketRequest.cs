namespace CinemAPI.Models.Contracts.Ticket
{
    public interface ITicketRequest
    {
        long ProjectionId { get; }

        string Guid { get; }

        int Row { get; }

        int Column { get; }
    }
}
