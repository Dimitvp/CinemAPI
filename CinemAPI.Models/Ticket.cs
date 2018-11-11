using System;
using CinemAPI.Models.Contracts.Ticket;

namespace CinemAPI.Models
{
    public class Ticket : ITicket, ITicketCreation, ITicketRequest
    {
        public Ticket(long projectionId, int row, int column)
        {
            this.ProjectionId = projectionId;
            this.Row = row;
            this.Column = column;
        }

        public Ticket(long projectionId, string guid, DateTime projectionStartDate, string movieName, string cinemaName, int roomNum, int row, int column)
        {
            this.ProjectionId = projectionId;
            this.Guid = guid;
            this.ProjectionStartDate = projectionStartDate;
            this.MovieName = movieName;
            this.CinemaName = cinemaName;
            this.RoomNum = roomNum;
            this.Row = row;
            this.Column = column;
        }

        public long Id { get; set; }

        public long ProjectionId { get; set; }

        public string Guid  { get; set; }

        public DateTime ProjectionStartDate { get; set; }

        public string MovieName { get; set; }

        public string CinemaName  { get; set; }

        public int RoomNum  { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }
    }
}
