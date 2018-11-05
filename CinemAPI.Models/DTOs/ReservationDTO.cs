using CinemAPI.Models.Contracts.Reservetion;
using System;

namespace CinemAPI.Models.DTOs
{
    public class ReservationDTO : IReservation

    {
        public long Id { get; set; }

        public long ProjectionId { get; set; }

        public virtual Projection Projection { get; set; }

        public string Guid { get; set; }

        public DateTime ProjectionStartDate { get; set; }

        public string MovieName { get; set; }

        public string CinemaName { get; set; }

        public int RoomNum { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }

        public bool IsActive { get; set; }
    }
}
