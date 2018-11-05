namespace CinemAPI.Models.Contracts.Reservetion
{
    public interface IReservationRequest
    {
        long ProjectionId { get; }

        int Row { get; }

        int Column { get; }
    }
}
