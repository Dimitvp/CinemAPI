using System;
using CinemAPI.Models.Contracts.Ticket;

namespace CinemAPI.Models.DTOs
{
    public class TicketDTO : ITicket
    {
        public TicketDTO()
        {
        }

        public TicketDTO(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }

        public long Id { get; set; }

        public long ProjectionId { get; set; }

        public string Guid { get; set; }

        public DateTime ProjectionStartDate { get; set; }

        public string MovieName { get; set; }

        public string CinemaName { get; set; }

        public int RoomNum { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }
    }
}
