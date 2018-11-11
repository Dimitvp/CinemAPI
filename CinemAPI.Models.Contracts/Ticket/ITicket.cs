using System;

namespace CinemAPI.Models.Contracts.Ticket
{
    public interface ITicket
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
    }
}
