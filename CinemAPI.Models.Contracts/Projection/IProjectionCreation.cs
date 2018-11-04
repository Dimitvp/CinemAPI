using System;

namespace CinemAPI.Models.Contracts.Projection
{
    public interface IProjectionCreation
    {
        int RoomId { get; }

        int MovieId { get; }

        DateTime StartDate { get; }

        int AvailableSeatsCount { get; }
    }
}