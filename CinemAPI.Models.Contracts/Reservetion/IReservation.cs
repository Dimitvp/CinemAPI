using System;

namespace CinemAPI.Models.Contracts.Reservetion
{
    public interface IReservation
    {
        long Id { get; }

        long ProjectionId { get; }

        string Guid { get; }

        DateTime ProjectionStartDate { get; }

        string MovieName { get; }

        string CinemaName { get; }

        int RoomNum { get; }

        int Row { get; }

        int Column { get; }

        bool IsActive { get; }
    }
}
