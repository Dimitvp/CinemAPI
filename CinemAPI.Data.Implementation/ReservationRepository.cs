using System.Linq;
using CinemAPI.Data.EF;
using CinemAPI.Models;
using CinemAPI.Models.Contracts.Reservetion;
using CinemAPI.Models.DTOs;

namespace CinemAPI.Data.Implementation
{
    public class ReservationRepository : IReservatioRepository
    {
        private readonly CinemaDbContext db;

        public ReservationRepository(CinemaDbContext db)
        {
            this.db = db;
        }

        //public IReservation Get(long projectionId, string gui, DateTime projectionStartDate, string movieName, string cinemaName, int roomNum, int row, int column)
        //{
        //    throw new NotImplementedException();
        //}

        public IReservation GetRestInfo(long id)
        {
            return db.Projections
                .Where(p => p.Id == id)
                .Select(s => new ReservationDTO
                {
                    ProjectionStartDate = s.StartDate,
                    MovieName = s.Movie.Name,
                    RoomNum = s.Room.Number,
                    CinemaName = s.Room.Cinema.Name
                })
                .Single();
        }

        public void Insert(IReservationCreation reserv)
        {
            Reservation newReserv = new Reservation(reserv.ProjectionId, reserv.Guid, reserv.ProjectionStartDate, reserv.MovieName, reserv.CinemaName, reserv.RoomNum, reserv.Row, reserv.Column, reserv.IsActive);

            db.Reservations.Add(newReserv);
            db.SaveChanges();
        }
    }
}
