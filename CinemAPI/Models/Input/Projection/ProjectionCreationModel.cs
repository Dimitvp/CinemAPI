using System;

namespace CinemAPI.Models.Input.Projection
{
    public class ProjectionCreationModel
    {
        public int RoomId { get; set; }

        public int MovieId { get; set; }

        public DateTime StartDate { get; set; }

        public int AvailableSeatsCount { get; set;}
    }
}