using System;

namespace CinemAPI.Models.Input.Reservation
{
    public class ReservationCreationModel
    {
        public long ProjectionId { get; set; }

        public string Gui { get; set; }

        public DateTime ProjectionStartDate { get; set; }

        public string MovieName { get; set; }

        public string CinemaName { get; set; }

        public int RoomNum { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }

        public bool IsActive { get; set; }
    }
}