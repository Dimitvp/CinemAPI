namespace CinemAPI.Models.Contracts.Reservetion
{
    public interface IReservationRequest
    {
        string Guid { get; set; }

        long ProjectionId { get; }

        int Row { get; }

        int Column { get; }
    }
}
