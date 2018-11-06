using CinemAPI.Models.Contracts.Reservetion;
using System;

namespace CinemAPI.Models.Input.Reservation
{
    public class ReservationTicketModel
    {
        public string Guid { get; set; }

        public DateTime ProjectionStartDate { get; set; }

        public string MovieName { get; set; }

        public string CinemaName { get; set; }

        public int RoomNum { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }
    }
}